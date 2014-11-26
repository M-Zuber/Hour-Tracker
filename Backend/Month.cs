using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Exceptions;
using System.Xml.Linq;
using System.IO;
using System.Globalization;

namespace Backend
{
    public class Month
    {
        private int _month { get; set; }
        private int _year { get; set; }

        public DateTime Date
        {
            get
            {
                return new DateTime(_year, _month, 1);
            }
        }

        public List<Day> Days { get; private set; }

        public TimeSpan TotalHoursInMonth
        {
            get
            {
                TimeSpan total = new TimeSpan(0, 0, 0);
                Days.ForEach(day => total += day.TotalHours);
                return total;
            }
        }

        public Month(int year, int month)
        {
            _month = month;
            _year = year;
            Days = new List<Day>();
            SetUpDays();
        }

        private void SetUpDays()
        {
            for (int dayIndex = 1; dayIndex <= DateTime.DaysInMonth(_year, _month); dayIndex++)
            {
                Days.Add(new Day(_year, _month, dayIndex));
            }
        }

        public void CheckIn(DateTime date, int hour, int minutes, int seconds)
        {
            if (date.Year != _year || date.Month != _month)
            {
                throw new InvalidTimePunchException("The date requested is not in this month");
            }

            Days.Single(day => day.Date.Day == date.Day).CheckIn(hour, minutes, seconds);
        }

        public void CheckOut(DateTime date, int hour, int minutes, int seconds)
        {
            if (date.Year != _year || date.Month != _month)
            {
                throw new InvalidTimePunchException("The date requested is not in this month");
            }

            Days.Single(day => day.Date.Day == date.Day).CheckOut(hour, minutes, seconds);
        }

        internal XElement ToXml()
        {
            XElement month = new XElement("month", new XAttribute("date", this.Date.ToString("MM/yyyy")));

            foreach (Day currDay in this.Days)
            {
                month.Add(currDay.ToXml());
            }

            month.Add(new XElement("total-hours-in-month", this.TotalHoursInMonth.TotalHours));

            return month;
        }

        public void SaveToFile(string filename)
        {
            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }

            this.ToXml().Save(filename);
        }

        internal static Month Parse(XElement element)
        {
            DateTime parsed = DateTime.ParseExact((string)element.Attribute("date"), "MM/yyyy", null, DateTimeStyles.None);
            Month newMonth = new Month(parsed.Year, parsed.Month);

            foreach (XElement currDay in element.Elements("day"))
            {
                Day newDay = Day.Parse(currDay);
                newMonth.Days[newDay.Date.Day - 1] = newDay;
            }

            return newMonth;
        }

        public static Month Load(string fileName)
        {
            return Month.Parse(XElement.Load(fileName));
        }
    }
}
