using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.BookingPage
{
    public class PaymentModel : PageModel
    {
        private readonly IBookingRepository _bookingRepo;

        [BindProperty]
        public Booking Booking { get; set; } = new Booking();

        public PaymentModel(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public void OnGet(int bookingId)
        {
            int? customerId = HttpContext.Session.GetInt32("customerId");

            if (!customerId.HasValue)
            {
                RedirectToPage("/Login");
            }

            Booking = _bookingRepo.GetBookingById(bookingId);

            if (Booking.CustomerId != customerId)
            {
                RedirectToPage("/Error");
            }
        }

        public IActionResult OnPost(int bookingId)
        {
            int? customerId = HttpContext.Session.GetInt32("customerId");

            if (!customerId.HasValue)
            {
                return RedirectToPage("/Login");
            }

            Booking.CustomerId = customerId.Value;

            var existingBooking = _bookingRepo.GetBookingById(bookingId);

            if (existingBooking == null || existingBooking.CustomerId != customerId)
            {
                return RedirectToPage("/Error");
            }

            existingBooking.Status = 1;
            existingBooking.ServiceFeedBack = Booking.ServiceFeedBack;
            _bookingRepo.UpdateBooking(existingBooking);

            return RedirectToPage("/BookingPage/BookingHistory");
        }

    }
}
