using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class HomeModel : PageModel
    {
        private readonly IBookingRepository _context;

        public HomeModel(IBookingRepository context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public IActionResult OnGet(DateTime today)
        {
            if (HttpContext.Session.GetInt32("art_email") == null)
            {
                return RedirectToPage("/Login");
                
            }
            int artistId = HttpContext.Session.GetInt32("art_email").Value;
            if (_context.GetBookings() != null)
            {
                today = DateTime.Today;
                Booking = _context.GetBookingInDayByArtistId(today, artistId);
                
            }
            return Page();
        }
    }
}
