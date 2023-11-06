using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class FeedbackModel : PageModel
    {
        BookingRepository bookingRepository = new BookingRepository();
        public required List<Booking> bookings;
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("art_email") == null)
            {
                return RedirectToPage("/Login");
            }
            int id = HttpContext.Session.GetInt32("art_email").Value;
            if (bookingRepository.GetBookings() != null)
            {
                bookings = bookingRepository.GetBookingByArtistId(id);
            }
            return Page();
        }
    }
}
