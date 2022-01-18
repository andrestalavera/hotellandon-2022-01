using HotelLandon.Data;
using HotelLandon.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelLandon.DemoEfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Saisir les informations d'un client NOM PRENOM DATE jj/mm/aaaa");
            string input = Console.ReadLine();

            string[] split = input.Split(' ');
            string lastName = split[0];
            string firstName = split[1];
            DateTime birthDate = DateTime.Parse(split[2]);
            
            Customer customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate
            };

            using (HotelLandonContext context = new HotelLandonContext())
            {
                context.Database.EnsureCreated();
                context.Database.Migrate();
                // on peut ajouter tout type d'objet présent dans le DbContext
                context.Add(customer);
                // on ne peut ajouter que des objets de type Customer :
                // context.Customers.Add(customer);
                context.SaveChanges();
            }            
        }
    }
}
