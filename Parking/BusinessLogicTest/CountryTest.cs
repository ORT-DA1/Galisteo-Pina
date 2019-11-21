using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;

namespace BusinessLogicTest
{
    [TestClass]
    public class CountryTest
    {

        [TestMethod]
        public void ValidateEmptyTest()
        {
            Assert.AreEqual(Country.GetCountriesInSystem().Count, 2);
        }
    }
}
