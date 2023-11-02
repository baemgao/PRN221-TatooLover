using BusinessObjects.DTO;
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

        //public List<Booking> GetBookings() => bookingDAO.GetBookings();
        public List<Booking> GetBookingInDayByArtistId(DateTime date, int id) => bookingDAO.GetBookingInDayByArtistId(date, id);
        public List<Booking> GetBookingByArtistId(int id) => bookingDAO.GetBookingByArtistId(id);
        public List<Booking> GetBookingByStudioId(int studioId) => bookingDAO.GetBookingByStudioId(studioId);

        public List<Booking> GetBookingInDayByStudioId(DateTime date, int studioId) => bookingDAO.GetBookingInDayByStudioId(date, studioId);

        public List<Booking> GetBookings() => BookingDAO.GetBookings();
        public Booking GetBookingById(int id) => BookingDAO.GetBookingById(id);
        public void SaveBooking(Booking c) => BookingDAO.SaveBooking(c);
        public void UpdateBooking(Booking c) => BookingDAO.UpdateBooking(c);
        public void DeleteBooking(Booking c) => BookingDAO.DeleteBooking(c);

        public List<Booking> GetBookingsByCustomerId(int customerId) => BookingDAO.GetBookingsByCustomerId(customerId);
    }
}
