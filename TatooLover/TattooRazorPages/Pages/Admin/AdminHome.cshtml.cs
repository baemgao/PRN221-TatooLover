using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.Admin
{
    public class AdminHomeModel : PageModel
    {
        public IBookingRepository bookingRepository = new BookingRepository();
        public IStudioRepository studioRepository = new StudioRepository();
        public ICustomerRepository customerRepository = new CustomerRepository();
        public IArtistRepository artistRepository = new ArtistRepository();

        public List<Customer> customerList = new List<Customer>();
        public List<Booking> bookingList = new List<Booking>();
        public List<Studio> studioList = new List<Studio>();
        public void OnGet()
        {
            customerList = customerRepository.GetCustomers();
            bookingList = bookingRepository.GetBookings();
            studioList = studioRepository.GetStudios();
        public ICustomerRepository _customer = new CustomerRepository();

        public IList<Customer> Customer { get; set; } = default!;
        
        public async Task OnGetAsync()
        {
            Customer = _customer.GetCustomers();
        }
    }
}
