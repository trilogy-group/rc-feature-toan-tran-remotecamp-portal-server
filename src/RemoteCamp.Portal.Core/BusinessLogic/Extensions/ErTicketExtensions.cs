using System;
using RemoteCamp.Portal.Core.BusinessLogic.Data;

namespace RemoteCamp.Portal.Core.BusinessLogic.Extensions
{
    public static class ErTicketExtensions
    {
        public static int GetNumberOfPassedWorkingDays(this ErTicket erTicket)
        {
            var dayCount = 0;
            var startDate = erTicket.StartDate.Value;
            var stopDate = DateTime.UtcNow;
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

        public static int GetNumberOfPassedWorkingDays(this DateTime startDate)
        {
            var dayCount = 0;
            var stopDate = DateTime.UtcNow;
            var localStartDate = startDate;

            while (localStartDate <= stopDate)
            {
                if (localStartDate.DayOfWeek != DayOfWeek.Saturday && localStartDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    ++dayCount;
                }
                localStartDate = localStartDate.AddDays(1);
            }
            return dayCount;
        }
    }
}
