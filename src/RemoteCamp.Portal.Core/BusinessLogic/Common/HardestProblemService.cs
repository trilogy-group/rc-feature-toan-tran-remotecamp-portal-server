using System;
using System.Collections.Generic;
using System.Linq;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.Infrastructure.Common;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public class HardestProblemService : IHardestProblemService
    {
        private readonly ITimeService _timeService;
        private const int RecordCount = 15;

        public HardestProblemService(ITimeService timeService)
        {
            _timeService = timeService;
        }
        
        public IList<ProfileHardestProblemByDay> GetHardestProblemsByDay(IList<RcTask> rcTasks, Profile profile)
        {
            var startDate = profile.StartDate.Value.Date;
            var currentDate = _timeService.UtcNow.Date;
            var endDate = startDate.AddDays(BusinessConstants.NumberOfDaysInRemoteCamp);
            
            var problemsByDay = CreateEmptyCollection(startDate, currentDate, endDate);
            var rcTasksGroupedByFirstSubmissionDate = rcTasks.
                OrderBy(x => x.FirstSubmissionDate).
                GroupBy(x =>
                {
                    if (x.FirstSubmissionDate.Value.DayOfWeek == DayOfWeek.Saturday ||
                        x.FirstSubmissionDate.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        var dayValue = x.FirstSubmissionDate.Value.DayOfWeek == DayOfWeek.Saturday ? -1 : -2;
                        var fridayCurrentweek = x.FirstSubmissionDate.Value.AddDays(dayValue);
                        x.FirstSubmissionDate = fridayCurrentweek;
                    }
                    return x.FirstSubmissionDate.Value.ToShortDateString();
                });

            foreach (var groupedRcTasks in rcTasksGroupedByFirstSubmissionDate)
            {
                var problem = new ProfileHardestProblemByDay();
                var submissionDate = groupedRcTasks.Key;
                foreach (var rcTask in groupedRcTasks)
                {
                    var failedRiqbs = (rcTask.FailedIqbs ?? Enumerable.Empty<RiqbItem>())
                        .Concat(rcTask.Reviews == null
                        ? Enumerable.Empty<RiqbItem>()
                        : rcTask.Reviews.SelectMany(x => x.FailedIqbs));
                    foreach (var failedRiqb in failedRiqbs)
                    {
                        var hardestProblem = problem.Items.FirstOrDefault(x => x.JiraKey == failedRiqb.JiraKey);
                        if (hardestProblem == null)
                        {
                            hardestProblem = new ProfileHardestProblem
                            {
                                JiraKey = failedRiqb.JiraKey,
                                Summary = failedRiqb.Summary,
                                Resolved = true
                            };
                            problem.Items.Add(hardestProblem);
                        }
                        
                        if (hardestProblem.FailedIn.All(x => x.JiraKey != rcTask.JiraKey))
                        {
                            hardestProblem.FailedIn.Add(new ProfileHardestProblem.FailedInIssue
                            {
                                JiraKey = rcTask.JiraKey,
                                Summary = rcTask.Summary
                            });
                        }
                    }
                }
                problemsByDay[submissionDate] = problem;
            }

            var hardestProblemsByDay = new List<ProfileHardestProblemByDay>();
            var currenWeekIndex = profile.GetCurrentWeekIndex();
            for (var i = 0; i < problemsByDay.Count; i++)
            {
                var currentRecord = problemsByDay.ElementAt(i);
                hardestProblemsByDay.Add(currentRecord.Value);

                // whatever IQB failure is in "> current workday of the IC - 5 workdays" is considered as "not resolved" problem
                if (currentRecord.Key == currentDate.GetCurrentWorkinDay().ToShortDateString())
                {
                    UpdatedCurrentDayOfWeekIqbResolutionStatus(hardestProblemsByDay);
                }

                // any occurrence of "not resolved problem" should be marked and highlighted in last week.
                // update all week Iqbs status to not resolved based on failed Iqb in last week .
                if (hardestProblemsByDay.Count == problemsByDay.Count
                    && hardestProblemsByDay.Count > RecordCount
                    && currenWeekIndex >= 3)
                {
                    UpdateNotResolvedIqbStatus(hardestProblemsByDay);
                }
            }

            return hardestProblemsByDay;
        }
        
         private static void UpdatedCurrentDayOfWeekIqbResolutionStatus(List<ProfileHardestProblemByDay> hardestProblems)
        {
            var start = 0;
            var loopConditionCount = 0;
            if (hardestProblems.Count < 5)
            {
                loopConditionCount = hardestProblems.Count;
            }
            else
            {
                start = hardestProblems.Count - 5;
                loopConditionCount = hardestProblems.Count;
            }
            var record = loopConditionCount < 0 ? 1 : loopConditionCount;
            var lastWeekData = hardestProblems.Skip(start).Take(record);
            var failedIqbInLastWeek = lastWeekData.Select(x => x.Items.Select(y => y.JiraKey)).ToList();
            UpdateResolutionStatus(hardestProblems, failedIqbInLastWeek);
        }

        private static void UpdateNotResolvedIqbStatus(List<ProfileHardestProblemByDay> hardestProblems)
        {
            var lastWeekData = hardestProblems.Skip(RecordCount).Take(hardestProblems.Count - RecordCount);
            var failedIqbInLastWeek = lastWeekData.Select(x => x.Items.Select(y => y.JiraKey)).ToList();
            UpdateResolutionStatus(hardestProblems, failedIqbInLastWeek);
        }

        private static void UpdateResolutionStatus(List<ProfileHardestProblemByDay> hardestProblems, List<IEnumerable<string>> failedIqbInLastWeek)
        {
            if (failedIqbInLastWeek.Any())
            {
                foreach (var record in failedIqbInLastWeek)
                {
                    foreach (var iqbKey in record)
                    {
                        foreach (var hardestProblem in hardestProblems)
                        {
                            foreach (var iqbItems in hardestProblem.Items)
                            {
                                if (iqbItems.JiraKey == iqbKey)
                                {
                                    iqbItems.Resolved = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        private static Dictionary<string, ProfileHardestProblemByDay> CreateEmptyCollection(DateTime startDate, DateTime currentDate, DateTime endDate)
        {
            var problemsDictionatyObject = new Dictionary<string, ProfileHardestProblemByDay>();
            for (var date = startDate; date < endDate; date = date.AddDays(1))
            {
                var shortDate = date.ToShortDateString();
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    problemsDictionatyObject.Add(shortDate, new ProfileHardestProblemByDay());
                }
                if (currentDate.Equals(date))
                {
                    break;
                }
            }

            return problemsDictionatyObject;
        }
    }
}