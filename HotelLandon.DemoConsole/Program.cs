using System;
using System.IO;
using HotelLandon.Models;

namespace HotelLandon.DemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prénom");
            string firstName = Console.ReadLine();

            Console.Write("Nom de famille");
            string lastName = Console.ReadLine();

            Console.WriteLine("Date de naissance");
            string birthDate = Console.ReadLine();

            Customer customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = DateTime.Parse(birthDate)
            };

            using (StreamWriter writer = new StreamWriter("data.csv"))
            {
                writer.Write(customer.ToCsv());
            }
        }
    }
}
