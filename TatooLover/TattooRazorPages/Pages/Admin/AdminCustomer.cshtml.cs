using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.Admin
{
    public class AdminCustomerModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
    public string SearchText { get; set; }

        public ICustomerRepository customerRepository = new CustomerRepository();
        public List<Customer> customerList = new List<Customer>();
        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("Email") == null)
            {
                RedirectToPage("/Login");
            }
            customerList = customerRepository.GetCustomers();
            customerList = customerRepository.GetCustomerByName(SearchText);
        }
    }
}
