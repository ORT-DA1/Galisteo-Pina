using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;

namespace BusinessLogicTest
{

    [TestClass]
    public class SmsTest
    {

        Sms sms;

        [TestInitialize]
        public void TestInitialize()
        {
            DateTime lowerLimit = DateTime.Parse("10:00");
            DateTime upperLimit = DateTime.Parse("18:00");
            sms = new Sms(lowerLimit, upperLimit);
        }

    }
}
