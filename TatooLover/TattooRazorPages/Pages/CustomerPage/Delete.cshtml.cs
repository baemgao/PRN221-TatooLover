
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;

namespace TattooRazorPages.Pages.CustomerPage
{
    public class DeleteModel : PageModel
    {
        public ICustomerRepository _customer = new CustomerRepository();

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = _customer.GetCustomerById(id.Value);

            if (Customer != null)
            {
                _customer.DeleteCustomer(Customer);
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}
