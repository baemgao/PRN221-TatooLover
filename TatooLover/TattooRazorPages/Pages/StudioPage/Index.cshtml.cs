using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace TattooRazorPages.Pages.StudioPage
{

    public class IndexModel : PageModel
    {
        public IBookingRepository bookingRepository = new BookingRepository();
        public IStudioRepository studioRepository = new StudioRepository();
        public ICustomerRepository customerRepository = new CustomerRepository();
        public IArtistRepository artistRepository = new ArtistRepository();

        public Studio studio { get; set; } = default!;
        public List<Booking> bookingList { get; set; } = default!;
        public DateTime today { get; set; }

        public IActionResult OnGet(int id)
        {
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (id != null && id >= 0)
            {
                today = DateTime.Today;
                studio = studioRepository.GetStudioById(id);
                bookingList = bookingRepository.GetBookingInDayByStudioId(id, today);
            }
            return Page();
        }
        public IActionResult OnPost(DateTime searchDate)
        {
            if (HttpContext.Session.GetInt32("id") != null)
            {
                int artistId = HttpContext.Session.GetInt32("id").Value;
                bookingList = bookingRepository.GetBookingInDayByStudioId(artistId, searchDate)
                    .ToList();

                if (!bookingList.Any())
                {
                    ViewData["Message"] = "No bookings found for the selected date!";
                }
            }
            return Page();
        }
    }
}
