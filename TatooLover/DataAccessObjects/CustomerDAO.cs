using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CustomerDAO
    {
        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    customers = context.Customers.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }

        public static Customer GetCustomerById(int id)
        {
            Customer customer = new Customer();
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    customer = context.Customers.SingleOrDefault(f => f.CustomerId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }

        public static Customer GetCustomerByEmail(string email)
        {
            Customer customer = new Customer();
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    customer = context.Customers.SingleOrDefault(f => f.Email == email);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }

        public static List<Customer> GetCustomerByName(string searchText)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        customers = context.Customers.Where(c => c.Name.Contains(searchText)).ToList();
                    }
                    else
                    {
                        customers = context.Customers.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }

        public static void SaveCustomer(Customer customer)
        {
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteCustomer(Customer customer)
        {
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    var p1 = context.Customers.SingleOrDefault(f => f.CustomerId == customer.CustomerId);
                    context.Customers.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateCustomer(Customer customer)
        {
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    context.Entry<Customer>(customer).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Customer AuthenticateCustomer(string email, string password)
        {
            using (var context = new Prn221TatooLoverContext())
            {
                var customer = context.Customers.FirstOrDefault(c => c.Email == email && c.Password == password);
                return customer;
            }
        }

    }
}
