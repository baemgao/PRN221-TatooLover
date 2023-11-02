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
    }
}
