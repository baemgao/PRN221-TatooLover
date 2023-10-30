using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;

namespace TattooRazorPages.Pages.CustomerPage
{
    public class IndexModel : PageModel
    {
        public ICustomerRepository _customer = new CustomerRepository();

        public IList<Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = _customer.GetCustomers();
        }
    }
}
