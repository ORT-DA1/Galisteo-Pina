using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using Entities.Validation;

namespace BusinessLogicTest
{

    [TestClass]
    public class SmsTest
    {

        Sms sms;
        static List<ISmsValidator> SmsValidators;

        [TestInitialize]
        public void TestInitialize()
        {
            DateTime lowerLimit = DateTime.Parse("10:00");
            DateTime upperLimit = DateTime.Parse("18:00");
            sms = new Sms(lowerLimit, upperLimit);
            SmsValidators = Sms.InitializeSmsValidators();

    }

        [TestMethod]
        public void InitializeSmsValidatorsTest()
        {
            List<ISmsValidator> smsValidators = Sms.InitializeSmsValidators();
            Assert.AreEqual(smsValidators.Count, 2);

        }


        [TestMethod]
        public void GetSmsValidatorTest()
        {
            ISmsValidator smsValidator = Sms.GetSmsValidator(new Country(Country.CountriesInSystem.URUGUAY.ToString()));
            Assert.AreEqual(smsValidator.SmsValidatorCountry, Country.CountriesInSystem.URUGUAY);

        }

        [TestMethod]
        public void SetHOurBoundsTest()
        {
            DateTime lower = DateTime.Now;
            DateTime upper = DateTime.Now;
            sms.SetHourBounds(lower, upper);

            Assert.IsTrue(sms.LowerHourLimit == lower && sms.UpperHourLimit == upper);

        }


    }
}
