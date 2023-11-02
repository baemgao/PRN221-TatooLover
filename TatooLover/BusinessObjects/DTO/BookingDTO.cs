using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class BookingDTO
    {
        public BookingDTO(Booking booking, Customer customer, Artist artist)
        {
            Booking = booking;
            Customer = customer;
            Artist = artist;
        }

        public Booking Booking { get; set; }
        public Customer Customer { get; set; }
        public Artist Artist { get; set; }
    }
}
