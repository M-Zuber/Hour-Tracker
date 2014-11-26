using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Tests.Helpers;
using Backend.Exceptions;

namespace Backend.Tests
{
    [TestClass]
    public class MonthTest
    {
        [TestMethod]
        public void Month_List_Of_Days_Is_Size_Of_Days_In_Month()
        {
            Month actual = new Month(2014, 9);

            Assert.AreEqual(30, actual.Days.Count);
        }

        [TestMethod]
        public void Month_CheckIn_Day_In_Month()
        {
            Month actual = new Month(2014, 9);

            actual.CheckIn(new DateTime(2014, 9, 7), 9, 0, 0);
            Assert.AreEqual("9:00:00 am", actual.Days.Single(day => day.Date.Day == 7).TimeIn.ToString("h:mm:ss tt"), true);
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(InvalidTimePunchException), "The date requested is not in this month")]
        public void Month_CheckIn_Month_Wrong()
        {
            Month actual = new Month(2014, 9);

            actual.CheckIn(new DateTime(2014, 10, 7), 9, 0, 0);
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(InvalidTimePunchException), "The date requested is not in this month")]
        public void Month_CheckIn_Year_Wrong()
        {
            Month actual = new Month(2014, 9);

            actual.CheckIn(new DateTime(2013, 9, 7), 9, 0, 0);
        }

        [TestMethod]
        public void Month_CheckOut_Day_In_Month()
        {
            Month actual = new Month(2014, 9);

            actual.CheckIn(new DateTime(2014, 9, 7), 9, 0, 0);
            actual.CheckOut(new DateTime(2014, 9, 7), 10, 0, 0);
            Assert.AreEqual("10:00:00 am", actual.Days.Single(day => day.Date.Day == 7).TimeOut.ToString("h:mm:ss tt"), true);
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(InvalidTimePunchException), "The date requested is not in this month")]
        public void Month_CheckOut_Month_Wrong()
        {
            Month actual = new Month(2014, 9);

            actual.CheckIn(new DateTime(2014, 9, 7), 9, 0, 0);
            actual.CheckOut(new DateTime(2014, 10, 7), 10, 0, 0);
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(InvalidTimePunchException), "The date requested is not in this month")]
        public void Month_CheckOut_Year_Wrong()
        {
            Month actual = new Month(2014, 9);

            actual.CheckIn(new DateTime(2014, 9, 7), 9, 0, 0);
            actual.CheckOut(new DateTime(2013, 9, 7), 10, 0, 0);
        }

    }
}
