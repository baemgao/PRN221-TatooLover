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

        string? code;
        Studio studio;

        public async Task OnGetAsync()
        {
            code = HttpContext.Session.GetString("code") ?? "default";
            if (!code.Equals("default"))
            {
                studio = studioRepository.GetStudioByCode(code);
            }
        }
    }
}
