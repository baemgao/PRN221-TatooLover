using BusinessObjects.Models;
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
        public List<Studio> GetStudios() => db.Studios.ToList();

        public static List<Studio> GetStudioByName(string searchText)
        {
            List<Studio> customers = new List<Studio>();
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        customers = context.Studios.Where(c => c.Name.Contains(searchText)).ToList();
                    }
                    else
                    {
                        customers = context.Studios.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }
    }
}
