using System;

namespace HotelLandon.Models
{
    public sealed class Customer : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ToCsv()
        {
            return $"{LastName};{FirstName};{BirthDate:O}";
        }
    }
}