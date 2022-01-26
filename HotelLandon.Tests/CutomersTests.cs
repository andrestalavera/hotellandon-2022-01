using HotelLandon.Models;
using HotelLandon.Repository;
using System;
using Xunit;

namespace HotelLandon.Tests
{
    public class CutomersTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange : initialiser vos variables
            Customer customer = new()
            {
                FirstName = "Andres"
            };

            // Act : Exécuter les opérations nécessaires


            // Assert : Vérifiez que le résultat attendu est égale à celui produit
            Assert.True(customer.FirstName.Length > 3);
        }

        [Fact]
        public void FirstNameDoitAvoir3Caracteres_AvecUneLettre()
        {
            // Arrange
            Customer customer = new()
            {
                FirstName = "A"
            };

            // Act

            // Assert
            Assert.False(customer.FirstName.Length > 3);
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            Customer customer = new()
            {
                BirthDate = DateTime.Today.AddYears(-120)
            };

            // Act

            // Assert
            Assert.Throws<TropVieuxException>(() =>
            {
                // Ajouter une vérification au niveau du Customer
            });
        }
    }
}
