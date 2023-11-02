using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;

namespace TattooRazorPages.Pages.CustomerPage
{
    public class EditModel : PageModel
    {
        public ICustomerRepository _customer = new CustomerRepository();

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int? customerId = HttpContext.Session.GetInt32("customerId");

            if (!customerId.HasValue)
            {
                return RedirectToPage("/Login");
            }

            Customer = _customer.GetCustomerById(customerId.Value);
            if (Customer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int? customerId = HttpContext.Session.GetInt32("customerId");

            if (!ModelState.IsValid || !customerId.HasValue)
            {
                return Page();
            }

            try
            {
                if (!CustomerExists(customerId.Value))
                {
                    return NotFound();
                }

                Customer.CustomerId = customerId.Value;

                _customer.UpdateCustomer(Customer);

                return RedirectToPage("/CustomerPage/CustomerDetail");
            }
            catch
            {
                return Page();
            }
        }

        private bool CustomerExists(int id)
        {

            Customer customer = _customer.GetCustomerById(id);


            return customer != null;
        }
    }
}
