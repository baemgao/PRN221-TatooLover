using BusinessObjects.Models;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void DeleteCustomer(Customer c) => CustomerDAO.DeleteCustomer(c);

        public Customer GetCustomerById(int id) => CustomerDAO.GetCustomerById(id);
        public Customer GetCustomerByEmail(string email) => CustomerDAO.GetCustomerByEmail(email);

        public List<Customer> GetCustomers() => CustomerDAO.GetCustomers();

        public void SaveCustomer(Customer c) => CustomerDAO.SaveCustomer(c);

        public void UpdateCustomer(Customer c) => CustomerDAO.UpdateCustomer(c);

        public Customer AuthenticateCustomer(string email, string password)
        {
            return CustomerDAO.AuthenticateCustomer(email, password);
        }
    }
}
