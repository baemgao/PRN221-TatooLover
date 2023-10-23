using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CustomerDAO
    {
        Prn221TatooLoverContext db = new Prn221TatooLoverContext();
        public List<Customer> GetCustomers() 
        {
            return db.Customers.ToList();
        }
    }
}
