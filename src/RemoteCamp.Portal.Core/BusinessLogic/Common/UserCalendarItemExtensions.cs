using System;
using RemoteCamp.Portal.Core.BusinessLogic.Data;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public static class UserCalendarItemExtensions
    {
        public static int GetDayIndex(this UserCalendarItem userCalendarItem)
        { 
            var dayIndexWhenSundayIsFirst = (int)Enum.Parse<DayOfWeek>(userCalendarItem.Day, true);
            var newIndex = dayIndexWhenSundayIsFirst - 1;
            if (newIndex < 0)
            {
                newIndex += 7;
            }

            return newIndex;
        }

        public static int GetRemoteUDayIndex(this UserCalendarItem userCalendarItem)
        {
            var weekIndex = userCalendarItem.WeekNumber - 1;
            return weekIndex * 7 + userCalendarItem.GetDayIndex();
        }
    }
}