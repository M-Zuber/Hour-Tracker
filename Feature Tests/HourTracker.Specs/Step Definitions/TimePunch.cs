using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Backend;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HourTracker.Specs.Step_Definitions
{
    [Binding]
    public class TimePunch
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        Day day = new Day(DateTime.Today);
        int _hour;
        int _minute;
        int _second;

        [Given(@"I have entered (.*) (.*) (.*) as my login time")]
        public void GivenIHaveEnteredAsMyLoginTime(int hour, int minute, int second)
        {
            _hour = hour;
            _minute = minute;
            _second = second;
        }

        [When(@"I checkin")]
        public void WhenIPressCheckin()
        {
            day.CheckIn(_hour, _minute, _second);
        }

        [Then(@"the time in should be (.*) today")]
        public void ThenTheTimeInShouldBeAmToday(string timeIn)
        {
            Assert.AreEqual(DateTime.Today, day.Date);
            Assert.AreEqual(timeIn, day.TimeIn.ToString("h:mm:ss tt"), true);
        }

        [Given(@"I have chosen (.*) as the clock in date")]
        public void GivenIHaveChosenAsTheClockInDate(DateTime checkInDate)
        {
            day = new Day(checkInDate);
        }

        [Then(@"the time in for the date (.*) should be (.*)")]
        public void ThenTheTimeInForTheDateShouldBeAm(DateTime checkInDate, string timeIn)
        {
            Assert.AreEqual(checkInDate.Date, day.Date.Date);
            Assert.AreEqual(timeIn, day.TimeIn.ToString("h:mm:ss tt"), true);
        }
    }
}