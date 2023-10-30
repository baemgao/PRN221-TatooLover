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
        public List<Booking> GetDay(DateTime date) => db.Bookings
            .Where(b => b.BookingDate.Date == date.Date)
            .ToList();
    }
}
