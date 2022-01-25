using HotelLandon.Data;
using HotelLandon.Models;
using HotelLandon.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
            DateTime birthDate = default;
            try
            {
               birthDate = DateTime.Parse(split[2]);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            
            Customer customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate
            };

            if (customer.BirthDate < DateTime.Today.AddYears(-100))
            {
                throw new TropVieuxException("Impossible que tu aies plus de 100 ans");
            }



            // using (HotelLandonContext context = new HotelLandonContext())
            // {
            //     context.Database.EnsureCreated();
            //     context.Database.Migrate();
            //     // on peut ajouter tout type d'objet présent dans le DbContext
            //     context.Add(customer);
            //     // on ne peut ajouter que des objets de type Customer :
            //     // context.Customers.Add(customer);
            //     if (context.Rooms.Any())
            //     {
            //         for (int i = 1; i < 10; i++)
            //         {
            //             context.Rooms.Add(new Room { Number = i, Floor = 0 });
            //         }
            //     }
            //     context.SaveChanges();
            // }
            //RepositoryBase<Customer> customersRepository = new RepositoryBase<Customer>();
            //customersRepository.Add(customer);

            //RepositoryBase<Room> roomsRepository = new RepositoryBase<Room>();
            //if (!roomsRepository.GetAll().Any())
            //{
            //    for (int i = 1; i < 10; i++)
            //    {
            //        roomsRepository.Add(new Room{ Number = i, Floor = 0 });
            //    }
            //}
        }
    }
}
