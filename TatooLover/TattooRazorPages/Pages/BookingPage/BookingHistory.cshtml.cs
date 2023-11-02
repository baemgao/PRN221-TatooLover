using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.BookingPage
{
    public class BookingHistoryModel : PageModel
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly ICustomerRepository _customerRepo;

        public BookingHistoryModel(IBookingRepository bookingRepo, ICustomerRepository customerRepo)
        {
            _bookingRepo = bookingRepo;
            _customerRepo = customerRepo;
        }

        public IList<Booking> CustomerBookings { get; set; } = new List<Booking>();

        public void OnGet()
        {
            int? customerId = HttpContext.Session.GetInt32("customerId");
            if (customerId.HasValue)
            {
                CustomerBookings = _bookingRepo.GetBookingsByCustomerId(customerId.Value);
            }
        }
    }
}
