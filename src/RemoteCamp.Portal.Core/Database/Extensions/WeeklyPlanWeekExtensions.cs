using System;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.Database.Model;

namespace RemoteCamp.Portal.Core.Database.Extensions
{
    public static class WeeklyPlanWeekExtensions
    {
        public static bool CanSubmit(this WeeklyPlanWeek weeklyPlanWeek, DateTime startDate, DayOfWeek deadLine)
        {
            var currentDate = DateTime.UtcNow;
            var currentWeekNumber = startDate.GetCurrentWeekNumber();
            return (int)weeklyPlanWeek.WeekNumber == currentWeekNumber && (int)currentDate.DayOfWeek <= (int)deadLine;
        }

        public static bool CanApprove(this WeeklyPlanWeek weeklyPlanWeek, DateTime startDate, DayOfWeek deadLine)
        {
            var currentDate = DateTime.UtcNow;
            var currentWeekNumber = startDate.GetCurrentWeekNumber();
            return (int)weeklyPlanWeek.WeekNumber == currentWeekNumber &&
                weeklyPlanWeek.Submitted &&
                (int)currentDate.DayOfWeek <= (int)deadLine;
        }
    }
}
