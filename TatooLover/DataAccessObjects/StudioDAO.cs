using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class StudioDAO
    {
        Prn221TatooLoverContext db = new Prn221TatooLoverContext();
        public List<Studio> GetStudios() => db.Studios
            .Include(s => s.Services)
            .Include(s => s.Artists)
            .ToList();

        public static List<Studio> GetStudioByName(string searchText)
        {
            List<Studio> studios = new List<Studio>();
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        studios = context.Studios.Where(c => c.Name.Contains(searchText)).ToList();
                    }
                    else
                    {
                        studios = context.Studios.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return studios;
        }

        public static void UpdateStudio(Studio studio)
        {
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    context.Update(studio);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<Service> GetServiceByName(string searchText)
        {
            List<Service> customers = new List<Service>();
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        customers = context.Services.Where(c => c.Name.Contains(searchText)).ToList();
                    }
                    else
                    {
                        customers = context.Services.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }

        public static void CreateStudio(Studio studio)
        {
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    // Thêm Studio mới vào cơ sở dữ liệu
                    context.Studios.Add(studio);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static double GetServicePriceByName(string serviceName)
        {
            double price = 0;
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    price = context.Services
                        .Where(s => s.Name == serviceName)
                        .Select(s => s.Price)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return price;
        }
    }
}
