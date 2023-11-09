using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.StudioPage
{
    public class HomeModel : PageModel
    {
        public IBookingRepository bookingRepository = new BookingRepository();
        public IStudioRepository studioRepository = new StudioRepository();
        public ICustomerRepository customerRepository = new CustomerRepository();
        public IArtistRepository artistRepository = new ArtistRepository();

        public Studio studio { get; set; } = default!;
        public IList<Booking> bookingList { get; set; } = default!;
        public DateTime today { get; set; }
        public int booking, service, feedback, artist;

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToPage("/Login");
            }
            int id = HttpContext.Session.GetInt32("id").Value;
            today = DateTime.Today;
            studio = studioRepository.GetStudioById(id);
            bookingList = bookingRepository.GetBookingInDayByStudioId(today, id);
            booking = bookingRepository.GetBookingByStudioId(id).Count();
            artist = artistRepository.GetArtistByStudioId(id).Count();
            service = studioRepository.GetServiceByStudioId(id).Count();
            feedback = bookingRepository.GetBookingByStudioId(id).Count();
            return Page();
        }
    }
}
