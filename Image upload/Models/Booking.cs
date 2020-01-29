using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image_upload.Models
{
    public class Booking
    {
        public int bookingId { get; set; }

        public int userId { get; set; }

        public int movieId { get; set; }

        public string booked_date { get; set; }

        Movie_schedule Movie_Schedule { get; set; }
        //int bookingId;
        //int userId;
        //int movieId;
        //List<Movie> bookedSeats;
        //int amount;
        //PaymentStatus status_of_payment;
        //Date booked_date;
        //Time movie_timing;
    }
}
