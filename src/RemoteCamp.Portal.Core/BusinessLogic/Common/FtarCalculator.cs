using System;
using System.Collections.Generic;
using System.Linq;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.Infrastructure.Jira;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    class FtarCalculator : IFtarCalculator
    {
        public double? CalculateActualValue(IEnumerable<RcTask> tasks, DateTime startDate, bool includeInReview)
        {
            return Calculate(tasks, startDate, includeInReview);
        }
        
        public double? CalculateGraduationValue(IEnumerable<RcTask> tasks, DateTime startDate, bool includeInReview)
        {
            return Calculate(tasks, startDate, includeInReview, 2);
        }

        public double? Calculate(IEnumerable<RcTask> tasks,
            DateTime startDate,
            bool includeInReview,
            int skipWeeks = 0)
        {
            var weekToCountFtar = 1 + skipWeeks;
            var currentWeek = Math.Min(startDate.GetCurrentWeekNumber(), BusinessConstants.WorkWeekCount);
            if (currentWeek < weekToCountFtar)
            {
                return null;
            }

            double numberOfTicketsWithFtarYesOrInReview = tasks.Count(
                x => x.FirstSubmissionDate.HasValue && startDate.GetCurrentWeekNumber(x.FirstSubmissionDate.Value) >= weekToCountFtar && 
                     (x.Ftar.HasValue && x.Ftar.Value || includeInReview && x.Status == JiraConstants.RcTaskStatuses.InReview && !x.Ftar.HasValue));
            double numberOfTicketsWithFtarOrInReview =
                tasks.Count(
                    x => x.FirstSubmissionDate.HasValue && startDate.GetCurrentWeekNumber(x.FirstSubmissionDate.Value) >= weekToCountFtar && 
                         (x.Ftar.HasValue || includeInReview && x.Status == JiraConstants.RcTaskStatuses.InReview));
            return numberOfTicketsWithFtarOrInReview == 0
                ? (double?)null
                : numberOfTicketsWithFtarYesOrInReview / numberOfTicketsWithFtarOrInReview;
        }
    }
}
