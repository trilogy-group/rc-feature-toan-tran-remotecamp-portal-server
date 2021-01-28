using System;
using System.Collections.Generic;
using System.Linq;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public class ScoreCalculator : IScoreCalculator
    {
        public double Calculate(IEnumerable<RcTask> tasks, string status)
        {
            return tasks.Where(x => x.Status == status).Sum(x => x.Score.Value);
        }
        
        public double CalculateDailyTarget(DateTime startDate)
        {
            var dailyTarget = 0.0;
            var currentWeek = Math.Min(startDate.GetCurrentWeekNumber(), BusinessConstants.WorkWeekCount);
            var currentDay = Math.Min(startDate.GetNumberOfPassedWorkingDays(), BusinessConstants.NumberOfWorkingDaysInRemoteCamp);

            for (var i = 1; i < currentWeek; i++)
            {
                dailyTarget += GetWeekPartialTarget(i, 5);
            }

            dailyTarget += GetWeekPartialTarget(currentWeek, (currentDay - 1) % 5 + 1);

            return dailyTarget;
        }

        private double GetWeekPartialTarget(int weekNumber, int dayNumber)
        {
            if (weekNumber == 1)
            {
                return 0.75 * dayNumber;
            }

            if (weekNumber == 2)
            {
                return 0.5 * dayNumber;
            }

            if (weekNumber == 3)
            {
                return 0.75 * dayNumber;
            }

            return dayNumber;
        }
    }
}
