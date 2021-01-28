using System;
using System.Collections.Generic;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Infrastructure.Common;

namespace RemoteCamp.Portal.Core.BusinessLogic.Extensions
{
    public static class ProfileExtensions
    {
        public static int GetCurrentWeekIndex(this Profile profile)
        {
            return profile.GetWeekIndex(DateTime.UtcNow);
        }

        public static int GetWeekIndex(this Profile profile, DateTime dateTime)
        {
            profile = profile ?? throw new ArgumentNullException(nameof(profile));
            if (!profile.StartDate.HasValue)
            {
                throw new ArgumentException("StartDate is not set", nameof(profile));
            }
            
            var daysPassed = (dateTime - profile.StartDate).Value.Days;
            var currentWeekNumber = (int)(daysPassed / 7);
            return currentWeekNumber;
        }
        
        public static int GetDayIndex(this Profile profile, DateTime dateTime)
        {
            profile = profile ?? throw new ArgumentNullException(nameof(profile));
            if (!profile.StartDate.HasValue)
            {
                throw new ArgumentException("StartDate is not set", nameof(profile));
            }
            
            return (dateTime - profile.StartDate.Value).Days;
        }        

        public static DateTime GetCurrentWorkinDay(this DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Saturday ||
                        dateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                var dayValue = dateTime.DayOfWeek == DayOfWeek.Saturday ? -1 : -2;
                dateTime = dateTime.AddDays(dayValue);
            }
            return dateTime;
        }

        public static int GetNumberOfPassedWorkingDays(this Profile profile, ITimeService timeService)
        {
            timeService = timeService ?? throw new ArgumentNullException(nameof(timeService));
            
            var dayCount = 0;
            var startDate = profile.StartDate.Value;
            var stopDate = timeService.UtcNow;
            while (startDate <= stopDate)
            {
                if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    ++dayCount;
                }
                startDate = startDate.AddDays(1);
            }
            return dayCount;
        }

        public static string ReplaceSingleQuoteToDoubleQuote(this string item)
        {
            return item.Replace("\"''\"", "'");
        }

        public static DateTime GetPreviousWorkingDay(this DateTime dateTime)
        {
            var day = dateTime.AddDays(-1);
            while (!day.IsWorkingDay())
            {
                day = day.AddDays(-1);
            }
            return day;
        }

        public static bool IsWorkingDay(this DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            return true;
        }
        
        public static int GetCurrentWeekNumber(this DateTime startDate, DateTime? currentDate = null)
        {
            var localCurrentDate = currentDate;
            if (currentDate == null)
            {
                localCurrentDate = DateTime.UtcNow;
            }

            var dayDifference = localCurrentDate.Value.Subtract(startDate).Days;
            var weekDifference = (int)Math.Floor(dayDifference / 7.0);
            var currentWeekNumber = weekDifference + 1;
            return currentWeekNumber;
        }
    }
}
