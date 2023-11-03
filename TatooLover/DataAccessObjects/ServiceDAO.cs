using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ServiceDAO
    {
        public List<Service> GetServices()
        {
            List<Service> services = new List<Service>();

            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    services = context.Services
                        .Include(s => s.Studio)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return services;
        }

        public List<Service> GetServiceByStudioId(int studioId)
        {
            List<Service> services = new List<Service>();

            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    services = context.Services
                        .Include(s => s.Studio)
                        .Where(s => s.StudioId == studioId)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return services;
        }

        public static List<Service> GetServiceByName(string searchText, int studioId)
        {
            List<Service> services = new List<Service>();
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        services = context.Services
                            .Where(s => s.Name.Contains(searchText) && s.StudioId == studioId)
                            .Include(s => s.Studio)
                            .ToList();
                    }
                    else
                    {
                        services = context.Services.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return services;
        }
    }
}
