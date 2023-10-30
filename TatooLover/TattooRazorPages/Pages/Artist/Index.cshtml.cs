using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace TattooRazorPages.Pages.Artist
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
            if (HttpContext.Session.Equals("art_email"))
            {
                return RedirectToPage("./Login");
            }
            if (_context.GetBookings != null)
            {
                Booking = _context.GetBookings();
            }
            return Page();
        }
        public IActionResult OnPost(DateTime? searchDate)
        {
            if (searchDate != null)
            {
                Booking = _context.GetBookings()
                 .Where(a => a.BookingDate.Date == searchDate)
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
