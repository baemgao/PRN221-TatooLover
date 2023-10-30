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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Kiểm tra xem khách hàng có tồn tại dựa trên ID
                if (!CustomerExists(Customer.CustomerId))
                {
                    return NotFound();
                }

                // Gọi phương thức để cập nhật thông tin khách hàng
                _customer.UpdateCustomer(Customer);

                return RedirectToPage("./Index");
            }
            catch
            {
                return Page();
            }
        }

        private bool CustomerExists(int id)
        {
            // kiểm tra xem khách hàng có tồn tại dựa trên ID
            Customer customer = _customer.GetCustomerById(id);

            // Trả về true nếu khách hàng tồn tại, ngược lại trả về false
            return customer != null;
        }
    }
}
