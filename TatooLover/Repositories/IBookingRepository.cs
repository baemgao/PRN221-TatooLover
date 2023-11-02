using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingRepository
    {
        public List<Booking> GetBookings();
        public List<Booking> GetBookingsByDay();
        public List<Booking> GetBookingToday(int studioID);
        public List<Booking> GetBookingByStudioId(int studioId);
        public Booking? GetBookingById(int bookingID);
        public List<Booking> GetBookingInDayByArtistId(DateTime date, int id);
        public List<Booking> GetBookingByArtistId(int id);
    }
}
