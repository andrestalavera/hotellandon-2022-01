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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HotelLandon;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("OnModelCreating");
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Number = 1, Floor = 0 },
                new Room { Id = 2, Number = 2, Floor = 0 },
                new Room { Id = 3, Number = 3, Floor = 0 },
                new Room { Id = 4, Number = 4, Floor = 0 },
                new Room { Id = 5, Number = 5, Floor = 0 },
                new Room { Id = 6, Number = 6, Floor = 0 },
                new Room { Id = 7, Number = 7, Floor = 0 },
                new Room { Id = 8, Number = 8, Floor = 0 }
            );
        }
    }
}
