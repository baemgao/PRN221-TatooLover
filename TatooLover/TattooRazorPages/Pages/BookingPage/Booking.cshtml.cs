using BusinessObjects.Models;
using DataAccessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.BookingPage
{
    public class BookingModel : PageModel
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IArtistRepository _artistRepo;
        private readonly IStudioRepository _studioRepo;

        [TempData]
        public string SignupMessage { get; set; }

        public BookingModel(IBookingRepository bookingRepo, IArtistRepository artistRepo, IStudioRepository studioRepo)
        {
            _bookingRepo = bookingRepo;
            _artistRepo = artistRepo;
            _studioRepo = studioRepo;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        [BindProperty]
        public IList<Artist> Artists { get; set; } = default!;

        [BindProperty]
        public IList<Service> Services { get; set; } = default!;

        public void OnGet()
        {
                Artists = _artistRepo.GetArtists();
                Services = _studioRepo.GetServices();
        }

        public async Task<IActionResult> OnPostAsync()
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
                ServiceId = Booking.ServiceId,
                Price = _studioRepo.GetServiceById(Booking.ServiceId).Price,
                BookingDate = Booking.BookingDate,
                BookingDateTime = Booking.BookingDateTime, 
                Note = Booking.Note,

            };
            //double servicePrice = _studioRepo.GetServicePriceByName(Booking.Price);
            //Booking.Price = servicePrice;

            _bookingRepo.SaveBooking(booking);
            TempData["BookingSuccess"] = "Booking thành công!";

            return RedirectToPage("/BookingPage/BookingHistory");
        }
    }
}
