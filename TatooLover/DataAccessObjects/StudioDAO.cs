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
    }
}
