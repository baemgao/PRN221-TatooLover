using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        public Booking? GetBookingById(int bookingID) => db.Bookings.FirstOrDefault(a => a.BookingId == bookingID);

        public List<Booking> GetBookingByStudioId(int studioId)
        {

            var artists = artistDAO.GetArtistByStudioId(studioId);

            return db.Bookings
              .Where(b => artists.Contains(b.Artist))
              .ToList();
        }

        public List<Booking> GetBookingsByDay() => db.Bookings.OrderByDescending(b => b.BookingDate).ToList();

        public List<Booking> GetBookingToday(int studioID)
        {
            List<Booking> bookingList = new List<Booking>();
            List<Artist> artistList = artistDAO.GetArtistByStudioId(studioID);

            return db.Bookings
                .Where(b => artistList.Contains(b.Artist) && b.BookingDate == DateTime.Today)
                .ToList();
        }
    }
}
