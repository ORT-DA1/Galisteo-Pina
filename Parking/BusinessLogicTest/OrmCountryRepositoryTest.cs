using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class OrmCountryRepositoryTest
    {
        Country TestCountryA { get; set; }
        Country TestCountryB { get; set; }
        List<Country> CountryList { get; set; }
        ParkingContext ParkingContext { get; set; }

        OrmCountryRepository ormCountryRepository;

        [TestInitialize]
        public void Initialize()
        {
            TestCountryA = new Country("NUEVA ZELANDIA");
            TestCountryB = new Country("MARRUECOS");
            CountryList = new List<Country>();
            CountryList.Add(TestCountryA);
            CountryList.Add(TestCountryB);
            ParkingContext = new ParkingContext("ParkingContextTest", new DropCreateDatabaseAlways<ParkingContext>());
            ormCountryRepository = new OrmCountryRepository(ParkingContext);
        }

        [TestMethod]
        public void GetCountriesNoneSavedYetTestPass()
        {
            List<Country> countriesSaved = ormCountryRepository.GetCountries().ToList();
            Assert.AreEqual(countriesSaved.Count, 0);
        }

        [TestMethod]
        public void AddCountriesTestPass()
        {
            ormCountryRepository.AddCountries(CountryList);
            ParkingContext.SaveChanges();
            List<Country> countriesSaved = ormCountryRepository.GetCountries().ToList();
            Assert.AreEqual(countriesSaved.Count, 2);
            Thread.Sleep(5000);
        }



    }
}
