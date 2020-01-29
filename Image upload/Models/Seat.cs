using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image_upload.Models
{
    public class Seat
    {
        public int seatId { get; set; }

        public SeatType SeatType { get; set; }


    }
    public enum SeatType
    {
        NORMAL,
        VIP
    }
}
