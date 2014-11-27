using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using Backend.Extensions;
using Backend.Exceptions;
using System.Globalization;

namespace Backend
{
    public class Day
    {
        #region Properties

        public DateTime Date { get; private set; }

        public SpecialDay SpecialDay { get; set; }

        public DateTime TimeIn { get; private set; }

        public DateTime TimeOut { get; private set; }

        public DayOfWeek DayOfWeek
        {
            get
            {
                return this.Date.DayOfWeek;
            }
        }

        public TimeSpan TotalHours
        {
            get
            {
                if (SpecialDay != null)
                {
                    if (SpecialDay.PayType == SpecialPayType.FullDay)
                    {
                        return new TimeSpan(9, 0, 0);
                    }
                    else if (SpecialDay.PayType == SpecialPayType.HalfDay)
                    {
                        return new TimeSpan(4, 30, 0);
                    }
                    else if (SpecialDay.PayType == SpecialPayType.NoPay)
                    {
                        return new TimeSpan(0, 0, 0);
                    }
                }
                return this.TimeOut - this.TimeIn;
            }
        }

        #endregion

        #region C'Tor

        public Day(int year, int month, int day)
        {
            Date = new DateTime(year, month, day);

            if ((this.DayOfWeek == DayOfWeek.Friday) || (this.DayOfWeek == DayOfWeek.Saturday))
            {
                this.SpecialDay = SpecialDay.Weekend;
            }
        }

        public Day(DateTime date)
            : this(date.Year, date.Month, date.Day)
        {
        }

        #endregion

        #region Main Methods

        public void CheckIn(int hour, int minute, int second)
        {
            DateTime checkInTime = this.Date.SetTime(hour, minute, second);

            if (this.TimeOut != default(DateTime) && (checkInTime > this.TimeOut))
            {
                throw new InvalidTimePunchException("The check in time can not exceed the check out time", new InvalidOperationException());
            }

            this.TimeIn = checkInTime;
        }

        public void CheckOut(int hour, int minute, int second)
        {
            DateTime checkOutTime = this.Date.SetTime(hour, minute, second);

            if (this.TimeIn == default(DateTime))
            {
                throw new InvalidTimePunchException("Check In must be performed before check out");
            }

            if (checkOutTime < this.TimeIn)
            {
                throw new InvalidTimePunchException("The check out time can not procedd the check in time", new InvalidOperationException());
            }

            this.TimeOut = checkOutTime;
        }

        #endregion

        #region Parse Methods

        internal XElement ToXml()
        {
            XElement day = new XElement("day");
            day.Add(new XElement("date", this.Date.ToString("dd/MM/yyyy")));
            day.Add(new XElement("time-in", this.TimeIn.ToString("h:mm:ss tt")));
            day.Add(new XElement("time-out", this.TimeOut.ToString("h:mm:ss tt")));
            day.Add(new XElement("day-of-week", this.DayOfWeek));
            day.Add(new XElement("total-hours", this.TotalHours.TotalHours));
            day.Add(this.SpecialDay != null ? this.SpecialDay.ToXml() : new XElement("special-type"));

            return day;
        }

        internal static Day Parse(XElement element)
        {
            Day newDay = new Day(DateTime.ParseExact((string)element.Element("date"), "dd/MM/yyyy", null));

            DateTime parsed;
            if (DateTime.TryParseExact((string)element.Element("time-in"), "h:mm:ss tt", null, DateTimeStyles.NoCurrentDateDefault, out parsed))
            {
                newDay.TimeIn = new DateTime(newDay.Date.Year, newDay.Date.Month, newDay.Date.Day, parsed.Hour, parsed.Minute, parsed.Second);
            }
            if (DateTime.TryParseExact((string)element.Element("time-out"), "h:mm:ss tt", null, DateTimeStyles.NoCurrentDateDefault, out parsed))
            {
                newDay.TimeOut = new DateTime(newDay.Date.Year, newDay.Date.Month, newDay.Date.Day, parsed.Hour, parsed.Minute, parsed.Second);
            }
            newDay.SpecialDay = SpecialDay.Parse(element.Element("special-type"));

            return newDay;
        }
        
        #endregion
    }
}
