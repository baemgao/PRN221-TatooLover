using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories;

namespace TattooRazorPages.Pages.ArtistPage
{
    public class BookingDetailsModel : PageModel
    {
        private readonly IBookingRepository _context;

        public BookingDetailsModel(IBookingRepository context)
        {
            _context = context;
        }

      public Booking Booking { get; set; } = default!; 

        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetInt32("art_email") == null)
            {
                return RedirectToPage("/Login");
            }
            if (id == null || _context.GetBookings() == null)
            {
                return NotFound();
            }

            var booking = _context.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            else 
            {
                Booking = booking;
            }
            return Page();
        }
    }
}
