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


        public List<Booking> GetBookingInDayByArtistId(DateTime date, int id) => db.Bookings
            .Where(b => b.ArtistId == id && b.BookingDateTime.Date == date.Date)
            .Include(b => b.Customer)
            .Include(c => c.Artist)
            .ToList();
        public List<Booking> GetBookingByArtistId(int id) => db.Bookings
            .Where(b => b.ArtistId == id)
            .Include(b => b.Customer)
            .Include(c => c.Artist)
            .ToList();
        public List<Booking> GetDay(DateTime date) => db.Bookings
           .Where(b => b.BookingDate.Date == date.Date)
           .ToList();
        public List<Booking> GetBookingInDayByStudioId(int studioId, DateTime date) => db.Bookings
             .Where(b => b.Artist.StudioId == studioId && b.BookingDate.Date == date.Date)
              .Include(b => b.Artist)
              .Include(b => b.Customer)
              .ToList();
        public static Booking GetBookingById(int id)
        {
            Booking booking = new Booking();
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    booking = context.Bookings
                        .Include(c => c.Artist)
                        .Include(b => b.Customer)
                        .SingleOrDefault(f => f.BookingId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return booking;
        }
        public static List<Booking> GetBookings()
        {
            List<Booking> bookings = new List<Booking>();
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    bookings = context.Bookings
                        .Include(c => c.Artist)
                        .Include(b => b.Customer)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bookings;
        }

        public static List<Booking> GetBookingsByCustomerId(int id)
        {
            List<Booking> bookings = new List<Booking>();
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    bookings = context.Bookings
                        .Include(c => c.Artist)
                        .Include(b => b.Customer)
                        .Where(b => b.CustomerId == id)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bookings;
        }
        public static void SaveBooking(Booking booking)
        {
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    context.Bookings.Add(booking);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteBooking(Booking booking)
        {
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    var p1 = context.Bookings.SingleOrDefault(f => f.BookingId == booking.BookingId);
                    context.Bookings.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateBooking(Booking booking)
        {
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    context.Entry<Booking>(booking).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
