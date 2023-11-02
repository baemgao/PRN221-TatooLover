using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class BookingDAO
    {
        Prn221TatooLoverContext db = new Prn221TatooLoverContext();
        ArtistDAO artistDAO = new ArtistDAO();

        public List<Booking> GetBookings() => db.Bookings
            .Include(b => b.Customer)
            .Include(c => c.Artist).ToList();
        public List<Booking> GetBookingInDayByArtistId(DateTime date, int id) => db.Bookings
            .Where(b => b.ArtistId == id && b.BookingDate.Date == date.Date)
            .Include(b => b.Customer)
            .Include(c => c.Artist)
            .ToList();
        public List<Booking> GetBookingsByArtistId(int artistId) => db.Bookings
            .Where(a => a.ArtistId == artistId)
            .ToList();
        public List<Booking> GetBookingByArtistId(int id) => db.Bookings
            .Include(b => b.Customer)
            .Include(c => c.Artist)
            .Where(b => b.ArtistId == id).ToList();
        public List<Booking> GetDay(DateTime date) => db.Bookings
           .Where(b => b.BookingDate.Date == date.Date)
           .ToList();
        public List<BookingDTO> GetBookinsInDayByStudioId(int studioId, DateTime date)
        {
            List<BookingDTO> bookingDTOs = new List<BookingDTO>();
            var artists = db.Artists.Where(a => a.StudioId == studioId).ToList();

            foreach (var artist in artists)
            {
                BookingDTO bookingDTO;
                List<Booking> bookings1 = GetBookingsByArtistId(artist.ArtistId);
                foreach (var booking in bookings1)
                {
                    Customer customer = db.Customers.Where(c => c.CustomerId == booking.CustomerId).FirstOrDefault();
                    bookingDTO = new BookingDTO(booking, customer, artist);
                    bookingDTOs.Add(bookingDTO);
                }
            }
            return bookingDTOs;
        }
    }
}
