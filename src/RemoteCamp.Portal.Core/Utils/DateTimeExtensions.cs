using System;
using System.Globalization;

namespace RemoteCamp.Portal.Core.Utils
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// This presumes that weeks start with Monday.
        /// Week 1 is the 1st week of the year with a Thursday in it.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        /// <remarks>
        ///     https://stackoverflow.com/questions/11154673/get-the-correct-week-number-of-a-given-date
        /// </remarks>
        public static int GetIso8601WeekOfYear(this DateTime dateTime)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dateTime);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                dateTime = dateTime.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        /// This checks if the start date is december 30, in which case, the year to be added to the label should be the next one
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int GetYearFromStartDate(this DateTime dateTime)
        {
            int year = (dateTime.Year % 100);
            if (dateTime.Day >= 28 && dateTime.Month == 12)
            {
                year++;
            }

            return year;
        }
    }
}
