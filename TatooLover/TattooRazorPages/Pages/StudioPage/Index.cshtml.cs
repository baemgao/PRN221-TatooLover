using BusinessObjects.DTO;
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

        public Customer customer { get; set; }
        public Studio studio { get; set; }
        public List<Booking> bookingList { get; set; }
        public DateTime today { get; set; }

        public void OnGet()
        {
            var id = HttpContext.Session.GetInt32("id") != null ?
           (int)HttpContext.Session.GetInt32("id")! : -1;

            if (id == null || id < 0)
            {
                NotFound(); return;
            }
            else
            {
                try
                {
                    today = DateTime.Today.Date;
                    studio = studioRepository.GetStudioById(id);
                    bookingList = bookingRepository.GetBookings();
                }
                catch (Exception ex)
                {
                    ViewData["Message"] = "Error getting data";
                }
            }
        }
    }
}
