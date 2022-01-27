using HotelLandon.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelLandon.Data
{
    public class HotelLandonContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public HotelLandonContext(DbContextOptions<HotelLandonContext> options)
            : base(options)
        {
        }
    }
}
