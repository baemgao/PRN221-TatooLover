using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.StudioPage
{
    public class FeedbackModel : PageModel
    {
        IBookingRepository bookingRepository = new BookingRepository();
        public List<Booking> bookings;
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("id") == null || HttpContext.Session.GetInt32("id") < 0)
            {
                return RedirectToPage("/Login");
            }
            int studioId = HttpContext.Session.GetInt32("id").Value;
            if (bookingRepository.GetBookingByStudioId(studioId) != null)
            {
                bookings = bookingRepository.GetBookingByStudioId(studioId);
            }
            return Page();
        }
    }
}
