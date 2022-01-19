using System;
using System.Runtime.Serialization;

namespace HotelLandon.Repository
{
    public class TropVieuxException : Exception
    {
        public TropVieuxException(string? message)
            : base(message)
        {
        }
    }
}
