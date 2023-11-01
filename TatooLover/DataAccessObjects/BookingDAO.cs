using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccessObjects
{
    public class BookingDAO
    {
        Prn221TatooLoverContext db = new Prn221TatooLoverContext();
        
        public List<Booking> GetBookings() => db.Bookings
            .Include(b => b.Customer)
            .Include(c => c.Artist).ToList();
        public List<Booking> GetDayByArtistId(DateTime date, int id) => db.Bookings
            .Where(b => b.ArtistId == id && b.BookingDate.Date == date.Date)
            .Include(b => b.Customer)
            .Include(c => c.Artist)
            .ToList();
        public List<Booking> GetBookingByArtistId(int id) => db.Bookings
            .Include(b => b.Customer)
            .Include(c => c.Artist)
            .Where(b => b.ArtistId == id).ToList();
    }
}
