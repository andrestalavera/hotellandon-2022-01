using System;

namespace HotelLandon.Models
{
    public class Reservation : EntityBase
    {
        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}