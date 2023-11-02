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
            customerList = customerRepository.GetCustomers();
            customerList = customerRepository.GetCustomerByName(SearchText);
        }
    }
}
