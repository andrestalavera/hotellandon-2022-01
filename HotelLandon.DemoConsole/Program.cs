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

            using (StreamWriter writer = File.AppendText("data.csv"))
            {
                writer.WriteLine(customer.ToCsv());
            }

            using (StreamReader reader = new StreamReader("data.csv"))
            {
                // string line = string.Empty;
                while (!reader.EndOfStream)
                // Alternative: while ((line = reader.ReadLine()) != null)
                {
                    string line = reader.ReadLine();
                    if (line != null || string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    string[] splittedData = line.Split(';');
                    Customer readedCustomer = new Customer()
                    {
                        LastName = splittedData[0],
                        FirstName = splittedData[1],
                        BirthDate = DateTime.Parse(splittedData[2])
                    };
                }
            }
        }
    }
}
