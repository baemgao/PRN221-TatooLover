using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.Admin
{
    public class AdminHomeModel : PageModel
    {
        public ICustomerRepository _customer = new CustomerRepository();

        public IList<Customer> Customer { get; set; } = default!;
        
        public async Task OnGetAsync()
        {
            Customer = _customer.GetCustomers();
        }
    }
}
