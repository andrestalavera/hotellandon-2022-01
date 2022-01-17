using System;

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
        }
    }
}
