using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class IndexModel : PageModel
    {
        private readonly IBookingRepository _context;

        public IndexModel(IBookingRepository context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get; set; } = default!;

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("art_email") == null)
            {
                return RedirectToPage("/Login");
            }
            int artistId = HttpContext.Session.GetInt32("art_email").Value;
            if (_context.GetBookings() != null)
            {
                Booking = _context.GetBookingByArtistId(artistId);
            }
            return Page();
        }
        public IActionResult OnPost(DateTime searchDate)
        {
            if (HttpContext.Session.GetInt32("art_email") != null)
            {
                int artistId = HttpContext.Session.GetInt32("art_email").Value;
                Booking = _context.GetBookingInDayByArtistId(searchDate, artistId)
                    .ToList();

                if (!Booking.Any())
                {
                    ViewData["Message"] = "No bookings found for the selected date!";
                }
            }
            return Page();
        }
    }
}
