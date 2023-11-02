using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.CustomerPage
{
    public class BillModel : PageModel
    {
        BookingRepository bookingRepository = new BookingRepository();
        public List<Bill> bills;
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("id") == null || HttpContext.Session.GetInt32("id") < 0)
            {
                return RedirectToPage("/Login");
            }
            int studioId = HttpContext.Session.GetInt32("id").Value;

            bills = bookingRepository.GetBillByStudioId(studioId);
            return Page();
        }
    }
}
