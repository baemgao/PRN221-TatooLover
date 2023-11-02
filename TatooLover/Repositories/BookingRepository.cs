using BusinessObjects.Models;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingRepository : IBookingRepository
    {
        BookingDAO bookingDAO = new BookingDAO();
        
        public List<Booking> GetBookings() => bookingDAO.GetBookings();
        public List<Booking> GetBookingInDayByArtistId(DateTime date, int id) => bookingDAO.GetBookingInDayByArtistId(date, id);
        public List<Booking> GetBookingByArtistId(int id) => bookingDAO.GetBookingByArtistId(id);
        public List<Booking> GetBookingsByDay() => bookingDAO.GetBookingsByDay();
        public List<Booking> GetBookingToday(int studioID) => bookingDAO.GetBookingToday(studioID);
        public List<Booking> GetBookingByStudioId(int studioId) => bookingDAO.GetBookingByStudioId(studioId);
        public Booking? GetBookingById(int bookingID) => bookingDAO.GetBookingById(bookingID);
    }
}
