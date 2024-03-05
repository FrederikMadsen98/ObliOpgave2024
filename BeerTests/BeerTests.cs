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
    public class BeerTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var beer = new Beer { Id = 1, Name = "Tuborg", Abv = 25 };

            string result = beer.ToString();

            Assert.AreEqual("1 Tuborg 25", result);
        }
        [TestMethod()]
        public void ValidateNameTest()
        {
            Beer beer = new Beer()
            {
                Id = 1,
                Name = "Tuborg",
                Abv = 25,
            };
            beer.ValidateName();

            Beer beerNull = new()
            {
                Id = 1,
                Name = null,
                Abv = 25,
            };
            Assert.ThrowsException<ArgumentNullException>(() => beerNull.ValidateName());

            Beer beerNoName = new()
            {
                Id = 1,
                Name = "",
                Abv = 25,
            };
            Assert.ThrowsException<ArgumentException>(() =>  beerNoName.ValidateName());

            Beer beerName = new()
            {
                Id = 1,
                Name = "Fm",
                Abv = 25,
            };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => beerName.ValidateName());
        }

        [TestMethod()]
        public void ValidateAbvTest()
        {
            Beer AbvTooHigh = new()
            {
                Id = 1,
                Name = "Tuborg",
                Abv = 68,
            };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>  AbvTooHigh.ValidateAbv());

            Beer AbvPerfect = new()
            {
                Id = 1,
                Name = "Tuborg",
                Abv = 25,
            };
            Assert.ThrowsException<ArgumentException>(() =>  AbvPerfect.ValidateAbv());
        }
    }
}