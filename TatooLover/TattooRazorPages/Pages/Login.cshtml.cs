using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories;

namespace TattooRazorPages.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ICustomerRepository _context;

        public LoginModel(ICustomerRepository context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;


        public IActionResult OnPost()
        {
            var account = _context.GetCustomers().FirstOrDefault(a => a.Email.Equals(Customer.Email) && a.Password.Equals(Customer.Password));
            if (account == null)
            {
                ViewData["Message"] = "You do not have permission to do this function!";
                return Page();
            }
            HttpContext.Session.SetString("email", account.Email);
            return RedirectToPage("./Index");
        }
    }
}
