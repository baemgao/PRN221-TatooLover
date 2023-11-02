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
        ArtistDAO artistDAO = new ArtistDAO();

        public Booking? GetBookingById(int bookingID) => bookingDAO.GetBookings().FirstOrDefault(a => a.BookingId == bookingID);
        public List<Booking> GetBookings() => bookingDAO.GetBookings().OrderByDescending(b => b.BookingDate).ToList();
        public List<Booking> GetDay(DateTime date) => bookingDAO.GetDay(date);
        //public List<Booking> GetBookings() => bookingDAO.GetBookings();
        public List<Booking> GetBookingInDayByArtistId(DateTime date, int id) => bookingDAO.GetBookingInDayByArtistId(date, id);
        public List<Booking> GetBookingByArtistId(int id) => bookingDAO.GetBookingByArtistId(id);

        public List<Booking> GetBookingInDayByStudioId(DateTime date, int studioId) => bookingDAO.GetBookinsInDayByStudioId(studioId, date);
    }
}
