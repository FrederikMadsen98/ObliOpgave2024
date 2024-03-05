using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObliOpgave2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObliOpgave2024.Tests
{
    [TestClass()]
    public class BeersRepositoryTests
    {

        [TestMethod]
        public void TestGetBeers_FilterByAbv()
        {
            // Arrange
            var repository = new BeersRepository();

            // Act
            var beers = repository.GetBeers(Abv: 20.0);

            // Assert
            foreach (var beer in beers)
            {
                Assert.IsTrue(beer.Abv > 20.0);
            }
        }

        [TestMethod]
        public void TestGetBeers_FilterByName()
        {
            // Arrange
            var repository = new BeersRepository();

            // Act
            var beers = repository.GetBeers(NameSort: "C").ToList();

            // Assert
            foreach (var beer in beers)
            {
                Assert.IsTrue(beer.Name.StartsWith("C"), $"Beer {beer.Name} does not start with 'C'.");
            }
        }

        [TestMethod]
        public void TestGetById_ExistingId()
        {
            // Arrange
            var repository = new BeersRepository();
            int existingId = 3;

            // Act
            var beer = repository.GetById(existingId);

            // Assert
            Assert.IsNotNull(beer);
            Assert.AreEqual(existingId, beer.Id);
        }
    }
}