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
        public List<Artist> artistList = new List<Artist>();

        public int CustomerCount { get; set; }
        public int StudioCount { get; set; }
        public int ArtistCount { get; set; }
        public int BookingCount { get; set; }
        public void OnGet()
        {
            customerList = customerRepository.GetCustomers();
            bookingList = bookingRepository.GetBookings();
            studioList = studioRepository.GetStudios();
            artistList = artistRepository.GetArtists();

            // Count the number of customers
            CustomerCount = customerList.Count;
            StudioCount = studioList.Count;
            ArtistCount = artistList.Count;
            BookingCount = bookingList.Count;
        }
    }
}
