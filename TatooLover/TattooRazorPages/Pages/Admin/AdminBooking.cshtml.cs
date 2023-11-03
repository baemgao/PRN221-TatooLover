using BusinessObjects.Models;
using DataAccessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;
using System.Collections.Generic;

namespace TattooRazorPages.Pages.Admin
{
    public class AdminBookingModel : PageModel
    {
        [BindProperty]
        public string SearchType { get; set; }
        [BindProperty]
        public string SearchText { get; set; }

        private IBookingRepository bookingRepository = new BookingRepository();
        public List<Booking> bookingList = new List<Booking>();

        public void OnGet()
        {
            bookingList = bookingRepository.GetBookings();
        }
    }
}
