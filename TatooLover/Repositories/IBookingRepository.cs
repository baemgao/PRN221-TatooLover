using BusinessObjects.DTO;
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

        public List<Booking> GetBookingInDayByArtistId(DateTime date, int id);
        public List<Booking> GetBookingInDayByStudioId(DateTime date, int studioId);
        public List<Booking> GetBookingByArtistId(int id);
        public List<Booking> GetBookingByStudioId(int studioId);
        List<Booking> GetBookings();
        List<Booking> GetBookingsByCustomerId(int customerId);
        Booking GetBookingById(int id);
        void SaveBooking(Booking c);
        void DeleteBooking(Booking c);
        void UpdateBooking(Booking c);
    }
}
