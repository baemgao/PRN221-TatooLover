using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("id") == null || HttpContext.Session.GetInt32("id") < 0)
            {
                return RedirectToPage("/Login");
            }
            int studioId = HttpContext.Session.GetInt32("id").Value;
            if (bookingRepository.GetBookingByStudioId(studioId) != null)
            {
                today = DateTime.Today;
                studio = studioRepository.GetStudioById(studioId);
                bookingList = bookingRepository.GetBookingByStudioId(studioId);
            }
            return Page();
        }
        public IActionResult OnPost(DateTime searchDate)
        {
            if (HttpContext.Session.GetInt32("id") != null)
            {
                int studioId = HttpContext.Session.GetInt32("id").Value;
                bookingList = bookingRepository.GetBookingInDayByStudioId(searchDate, studioId)
                    .ToList();

                if (!bookingList.Any())
                {
                    ViewData["Message"] = "No bookings found for the selected date!";
                }
                today = DateTime.Today;
            }
            return Page();
        }
    }
}
