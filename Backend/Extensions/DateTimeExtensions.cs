using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime SetTime(this DateTime date, int hour, int minute, int seconds)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException("hour", "The range of valid values are 0-23");
            }

            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException("minute", "The range of valid values are 0-59");
            }

            if (seconds < 0 || seconds > 59)
            {
                throw new ArgumentOutOfRangeException("seconds", "The range of valid values are 0-59");
            }

            return new DateTime(date.Year, date.Month, date.Day, hour, minute, seconds);
        }
    }
}
