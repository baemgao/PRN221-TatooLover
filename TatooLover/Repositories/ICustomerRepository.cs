using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        Customer GetCustomerByEmail(string email);
        void SaveCustomer(Customer c);
        void DeleteCustomer(Customer c);
        void UpdateCustomer(Customer c);
        Customer AuthenticateCustomer(string email, string password);
    }
}
