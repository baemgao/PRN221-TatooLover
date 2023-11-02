using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.Admin
{
    public class AdminBookingModel : PageModel
    {
        public IBookingRepository bookingRepository = new BookingRepository();
        public List<Booking> bookingList = new List<Booking>();
        public void OnGet()
        {
            bookingList = bookingRepository.GetBookings();
        }
    }
}
