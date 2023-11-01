using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages
{
    public class SignupModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;

        [BindProperty]
        public Customer Customer { get; set; }

        [TempData]
        public string SignupMessage { get; set; }

        public SignupModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingCustomer = _customerRepository.GetCustomerByEmail(Customer.Email);
            if (existingCustomer != null)
            {
                ModelState.AddModelError(string.Empty, "Email already exists.");
                return Page();
            }

            _customerRepository.SaveCustomer(Customer);

            TempData["SignupMessage"] = "Sign up successfully!!";

            return RedirectToPage("./Signup");
        }
    }


}
