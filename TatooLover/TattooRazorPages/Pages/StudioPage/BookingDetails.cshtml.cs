using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.StudioPage
{
    public class DetailsModel : PageModel
    {
        public IBookingRepository bookingRepository = new BookingRepository();
        public IStudioRepository studioRepository = new StudioRepository();
        public ICustomerRepository customerRepository = new CustomerRepository();
        public IArtistRepository artistRepository = new ArtistRepository();

        public Booking booking { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            booking = bookingRepository.GetBookingById(id.Value);

            if (booking == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
