using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.BookingPage
{
    public class BookingModel : PageModel
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IArtistRepository _artistRepo;

        [TempData]
        public string SignupMessage { get; set; }

        public BookingModel(IBookingRepository bookingRepo, IArtistRepository artistRepo)
        {
            _bookingRepo = bookingRepo;
            _artistRepo = artistRepo;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        [BindProperty]
        public IList<Artist> Artists { get; set; } = default!;

        public void OnGet()
        {
                Artists = _artistRepo.GetArtists();
        }

        public async Task<IActionResult> OnPostAsync(double Price,DateTime BookingDate, DateTime BookingDateTime, string Note, int ArtistId, int Status)
        {

            int? customerId = HttpContext.Session.GetInt32("customerId");

            if (!customerId.HasValue)
            {
                return RedirectToPage("/Login");
            }

            var booking = new Booking
            {
                CustomerId = customerId.Value,
                ArtistId = Booking.ArtistId,
                Price = Booking.Price,
                BookingDate = Booking.BookingDate,
                BookingDateTime = Booking.BookingDateTime, 
                Note = Booking.Note,
                //Status = Booking.Status
            };
            _bookingRepo.SaveBooking(booking);
            TempData["BookingSuccess"] = "Booking thành công!";

            return RedirectToPage("/BookingPage/BookingHistory");
        }
    }
}
