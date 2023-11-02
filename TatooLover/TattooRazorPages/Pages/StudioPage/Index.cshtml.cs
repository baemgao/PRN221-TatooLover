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

        int id;
        public Studio studio { get; set; }
        public List<Booking> bookingList { get; set; }
        public DateTime today { get; set; }

        public async Task OnGetAsync()
        {
            id = (int)HttpContext.Session.GetInt32("id");
            if (id != null && id >= 0)
            {
                today = DateTime.Today;
                studio = studioRepository.GetStudioById(id);
                bookingList = bookingRepository.GetBookingInDayByStudioId(today, id);
            }
        }
    }
}
