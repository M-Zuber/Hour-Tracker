using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend;
using Backend.Exceptions;
using Backend.Tests.Helpers;

namespace Backend.Tests
{
    [TestClass]
    public class DayTests
    {
        #region General Tests

        [TestMethod]
        public void Day_Day_Of_Week_Correct()
        {
            Day myDay = new Day(DateTime.Today);

            Assert.AreEqual(DateTime.Today.DayOfWeek, myDay.DayOfWeek);
        }

        [TestMethod]
        public void Day_Regular_Day_Has_Total_Hours_From_Check_In_Out()
        {
            Day myDay = new Day(2014, 9, 4);

        }

        #endregion

        #region Special Type Tests

        [TestMethod]
        public void Day_Friday_Has_Special_Type_Of_No_Pay()
        {
            Day myDay = new Day(2014, 9, 5);

            Assert.AreEqual(DayOfWeek.Friday, myDay.DayOfWeek);
            Assert.AreEqual(SpecialPayType.NoPay, myDay.SpecialDay.PayType);
        }

        [TestMethod]
        public void Day_Saturday_Has_Special_Type_Of_No_Pay()
        {
            Day myDay = new Day(2014, 9, 6);

            Assert.AreEqual(DayOfWeek.Saturday, myDay.DayOfWeek);
            Assert.AreEqual(SpecialPayType.NoPay, myDay.SpecialDay.PayType);
        }

        [TestMethod]
        public void Day_Regular_Thrusday_Has_Null_Special_Type()
        {
            Day myDay = new Day(2014, 9, 4);

            Assert.AreEqual(DayOfWeek.Thursday, myDay.DayOfWeek);
            Assert.IsNull(myDay.SpecialDay);
        }

        [TestMethod]
        public void Day_Full_Day_Has_Nine_Hours_Total()
        {
            Day myDay = new Day(2014, 9, 4);
            myDay.SpecialDay = new SpecialDay("whatever", SpecialPayType.FullDay);

            Assert.AreEqual(9, myDay.TotalHours.Hours);
        }

        [TestMethod]
        public void Day_Half_Day_Has_Four_and_Half_Hours_Total()
        {
            Day myDay = new Day(2014, 9, 4);
            myDay.SpecialDay = new SpecialDay("whatever", SpecialPayType.HalfDay);

            Assert.AreEqual(4.5, myDay.TotalHours.TotalHours);
        }

        [TestMethod]
        public void Day_No_Pay_Has_Zero_Hours_Total()
        {
            Day myDay = new Day(2014, 9, 5);

            Assert.AreEqual(0, myDay.TotalHours.TotalHours);
        }

        #endregion

        #region CheckIn Tests
        
        [TestMethod]
        public void Day_CheckIn_Time_Before_CheckOut_Time()
        {
            Day actual = new Day(2014, 9, 7);
            
            actual.SetPrivateProperty<DateTime>("TimeOut", new DateTime(2014,9,7,10,40,0));
            actual.CheckIn(9, 40, 0);

            DateTime expected = new DateTime(2014, 9, 7, 9, 40, 0); 

            Assert.AreEqual(expected, actual.TimeIn);
        }

        [TestMethod]
        public void Day_CheckIn_With_No_CheckOut()
        {
            Day actual = new Day(2014, 9, 7);

            actual.CheckIn(9, 40, 0);

            DateTime expected = new DateTime(2014, 9, 7, 9, 40, 0);

            Assert.AreEqual(expected, actual.TimeIn);
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(InvalidTimePunchException), "The check in time can not exceed the check out time")]
        public void Day_CheckIn_Time_After_Checkout_Time()
        {
            Day actual = new Day(2014, 9, 7);

            actual.CheckIn(9, 40, 0);
            actual.CheckOut(13, 40, 0);
            actual.CheckIn(14, 40, 0);
        }

        #endregion

        #region CheckOut Tests

        [TestMethod]
        public void Day_CheckOut_After_CheckIn_Time()
        {
            Day actual = new Day(2014, 9, 7);

            actual.CheckIn(9, 0, 0);
            actual.CheckOut(18, 20, 0);
            
            DateTime expected = new DateTime(2014, 9, 7, 18, 20, 0);

            Assert.AreEqual(expected, actual.TimeOut);
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(InvalidTimePunchException), "Check In must be performed before check out")]
        public void Day_CheckOut_With_No_CheckIn()
        {
            Day actual = new Day(2014, 9, 7);

            actual.CheckOut(18, 20, 0);
        }

        [TestMethod]
        [ExpectedExceptionAndMessage(typeof(InvalidTimePunchException), "The check out time can not procedd the check in time")]
        public void Day_CheckOut_Before_CheckIn_Time()
        {
            Day actual = new Day(2014, 9, 7);

            actual.CheckIn(18, 20, 0);
            actual.CheckOut(9, 0, 0);
        }

        #endregion

        #region Total Hour Tests

        [TestMethod]
        public void Day_Total_Hours_With_CheckIn_and_Out_One_Hour()
        {
            Day actual = new Day(2014, 09, 07);

            actual.CheckIn(9, 0, 0);
            actual.CheckOut(10, 0, 0);

            TimeSpan expected = new TimeSpan(1, 0, 0);

            Assert.AreEqual(expected.Hours, actual.TotalHours.Hours);
        }

        [TestMethod]
        public void Day_Total_Hours_With_CheckIn_and_Out_Twelve_Hour()
        {
            Day actual = new Day(2014, 09, 07);

            actual.CheckIn(9, 0, 0);
            actual.CheckOut(21, 0, 0);

            TimeSpan expected = new TimeSpan(12, 0, 0);

            Assert.AreEqual(expected.Hours, actual.TotalHours.Hours);
        }

        #endregion
    }
}
