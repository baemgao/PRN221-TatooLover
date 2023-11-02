using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.CustomerPage
{
    public class CustomerDetailModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerDetailModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGet()
        {
            int? customerId = HttpContext.Session.GetInt32("customerId");
            if (!customerId.HasValue)
            {
                return RedirectToPage("/Login");
            }

            Customer = _customerRepository.GetCustomerById(customerId.Value);
            if (Customer == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
