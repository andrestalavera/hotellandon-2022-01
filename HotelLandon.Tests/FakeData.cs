using HotelLandon.Models;
using System;
using System.Collections.Generic;

namespace HotelLandon.Tests
{
    public class FakeData
    {
        public static List<Customer> Customers => new()
        {
            new()
            {
                Id = 1,
                FirstName = Faker.Name.FirstName(),
                LastName = Faker.Name.LastName(),
                BirthDate = Faker.Date.Birthday(18)
            },
            new()
            {
                Id = 2,
                FirstName = Faker.Name.FirstName(),
                LastName = Faker.Name.LastName(),
                BirthDate = Faker.Date.Birthday(18)
            },
            new()
            {
                Id = 3,
                FirstName = Faker.Name.FirstName(),
                LastName = Faker.Name.LastName(),
                BirthDate = Faker.Date.Birthday(18)
            },
        };
        public static List<Room> Rooms => new()
        {
            new()
            {
                Id = 1,
                Number = 1,
            },
            new()
            {
                Id = 2,
                Number = 2,
            },
            new()
            {
                Id = 3,
                Number = 3,
            }
        };

    }
}
