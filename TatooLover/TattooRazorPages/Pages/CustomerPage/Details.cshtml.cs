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
    public class DetailsModel : PageModel
    {
        public ICustomerRepository _customer = new CustomerRepository();

        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            Customer = _customer.GetCustomerById(id.Value);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
