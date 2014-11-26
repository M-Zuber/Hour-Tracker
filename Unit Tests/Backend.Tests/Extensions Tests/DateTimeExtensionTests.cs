using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Extensions;

namespace Backend.Tests.Extensions_Tests
{
    [TestClass]
    public class DateTimeExtensionTests
    {

        [TestMethod]
        public void DateTime_SetTime_From_Raw_Values()
        {
            DateTime myDateTime = new DateTime(2014, 01, 01);
            DateTime myTime = myDateTime.SetTime(12, 30, 5);

            Assert.AreEqual(myDateTime.Date, myTime.Date);
            Assert.AreEqual(12, myTime.Hour);
            Assert.AreEqual(30, myTime.Minute);
            Assert.AreEqual(5, myTime.Second);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DateTime_SetTime_With_Hour_Above_Bounds()
        {
            DateTime myDateTime = new DateTime(2014, 01, 01).SetTime(24, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DateTime_SetTime_With_Hour_Below_Bounds()
        {
            DateTime myDateTime = new DateTime(2014, 01, 01).SetTime(-1, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DateTime_SetTime_With_Minutes_Above_Bounds()
        {
            DateTime myDateTime = new DateTime(2014, 01, 01).SetTime(0, 60, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DateTime_SetTime_With_Minutes_Below_Bounds()
        {
            DateTime myDateTime = new DateTime(2014, 01, 01).SetTime(0, -1, 0);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DateTime_SetTime_With_Seconds_Above_Bounds()
        {
            DateTime myDateTime = new DateTime(2014, 01, 01).SetTime(0, 0, 60);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DateTime_SetTime_With_Seconds_Below_Bounds()
        {
            DateTime myDateTime = new DateTime(2014, 01, 01).SetTime(0, 0, -1);
        }
    }
}
