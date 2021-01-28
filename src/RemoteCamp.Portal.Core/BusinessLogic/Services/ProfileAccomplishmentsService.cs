using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.Common;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteU.Component.NoSqlClient;
using static RemoteCamp.Portal.Core.Infrastructure.Jira.JiraConstants;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public class ProfileAccomplishmentsService : IProfileAccomplishmentsService
    {
        private readonly IJiraUserRepository _jiraUserRepository;
        private readonly IRcTaskJiraRepository _rcTaskRepository;
        private readonly IProfileService _profileService;
        private readonly IFtarCalculator _ftarCalculator;
        private readonly IScoreCalculator _scoreCalculator;
        private readonly ITimeService _timeService;
        private readonly IWeeklyPlanService _weeklyPlanService;
        private readonly IErDocumentRepository _erDocumentRepository;
        private readonly IQualityTargetProvider _qualityTargetProvider;

        public ProfileAccomplishmentsService(
            IJiraUserRepository jiraUserRepository,
            IRcTaskJiraRepository rcTaskRepository,
            IProfileService profileService,
            IFtarCalculator ftarCalculator,
            IScoreCalculator scoreCalculator,
            ITimeService timeService,
            IWeeklyPlanService weeklyPlanService,
            IErDocumentRepository erDocumentRepository,
            IQualityTargetProvider qualityTargetProvider)
        {
            _jiraUserRepository = jiraUserRepository;
            _rcTaskRepository = rcTaskRepository;
            _profileService = profileService;
            _ftarCalculator = ftarCalculator;
            _scoreCalculator = scoreCalculator;
            _timeService = timeService;
            _weeklyPlanService = weeklyPlanService;
            _erDocumentRepository = erDocumentRepository;
            _qualityTargetProvider = qualityTargetProvider;
        }

        public async Task<ServiceValueResponse<ProfileAccomplishments>> GetAsync(string email)
        {
            var getProfileTask = _profileService.GetAsync(email);
            var getWeeklyPlanTask = _weeklyPlanService.GetAllAsync(email);

            var profileResponse = await getProfileTask;
            var weeklyPlan = await getWeeklyPlanTask;

            if (!profileResponse.IsSuccess)
            {
                return ServiceValueResponse<ProfileAccomplishments>.FromErrors(profileResponse.Errors);
            }

            if (!weeklyPlan.IsSuccess)
            {
                return ServiceValueResponse<ProfileAccomplishments>.FromErrors(profileResponse.Errors);
            }

            var profile = profileResponse.Value;
            var rcTickets = new List<RcTask>();
            if (profile.Status != ErTicketStatuses.RcActive)
            {
                var document = await _erDocumentRepository.GetErDocumentById(profile.JiraId);
                if (document != null)
                {
                    rcTickets.AddRange(document.GetRcTask());
                }
            }
            else
            {
                var jiraUser = await _jiraUserRepository.GetByEmailAsync(email);

                if (jiraUser == null)
                {
                    return ServiceValueResponse<ProfileAccomplishments>.NotFound($"User with email {email} was not found");
                }
                rcTickets = await _rcTaskRepository.FindByAssigneeAsync(jiraUser.AccountId, RcTaskLoadOptions.FirstSubmissionDate
                                                                                               | RcTaskLoadOptions.Status
                                                                                               | RcTaskLoadOptions.Ftar
                                                                                               | RcTaskLoadOptions.Score);
            }

            var now = _timeService.UtcNow.Date;
            var startDate = profile.StartDate.Value.Date;
            var days = Math.Min(profile.GetNumberOfPassedWorkingDays(_timeService), BusinessConstants.NumberOfWorkingDaysInRemoteCamp);
            var targetForToday = _scoreCalculator.CalculateDailyTarget(startDate);

            var daysPast = Math.Min((now - startDate).Days, BusinessConstants.NumberOfDaysInRemoteCamp - 1);
            var weeksPast = Math.Min(daysPast / 7, 3);

            return new ServiceValueResponse<ProfileAccomplishments>
            {
                Value = new ProfileAccomplishments
                {
                    QualitySummary =
                    {
                        Approved = _ftarCalculator.CalculateActualValue(rcTickets, startDate, false),
                        TargetForToday = _qualityTargetProvider.GetActualTarget()
                    },
                    GraduationQualitySummary =
                    {
                        Approved = _ftarCalculator.CalculateGraduationValue(rcTickets, startDate, false),
                        TargetForToday = _qualityTargetProvider.GetGraduationTarget(profile)
                    },
                    ScoreSummary =
                    {
                        Approved = _scoreCalculator.Calculate(rcTickets, JiraConstants.RcTaskStatuses.Approved),
                        InReview = _scoreCalculator.Calculate(rcTickets, JiraConstants.RcTaskStatuses.InReview),
                        InProgress = _scoreCalculator.Calculate(rcTickets, JiraConstants.RcTaskStatuses.InProgress),
                        TargetForToday = targetForToday
                    },
                    Weekly = Enumerable.Range(0, Math.Max(weeksPast + 1, 0)).Select(
                        weekIndex =>
                        {
                            var weekTickets = rcTickets
                                .Where(x => x.FirstSubmissionDate.HasValue)
                                .Where(x =>
                                    x.FirstSubmissionDate.Value.Date >= startDate.AddDays(weekIndex * 7)
                                    && x.FirstSubmissionDate.Value.Date < startDate.AddDays((weekIndex + 1) * 7));
                            return new ProfileAccomplishments.WeeklyData
                            {
                                Productivity = _scoreCalculator.Calculate(weekTickets, JiraConstants.RcTaskStatuses.Approved),
                                Quality = _ftarCalculator.CalculateActualValue(weekTickets, startDate, false)
                            };
                        })
                        .ToList(),
                    ModuleDistribution = GetModuleDistribution(rcTickets, startDate, weeksPast),
                    Daily = Enumerable.Range(0, Math.Max(daysPast + 1, 0)).Select(
                        dayIndex =>
                        {
                            var date = startDate.AddDays(dayIndex);
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {
                                return null;
                            }

                            var dayTickets = rcTickets
                                .Where(x => x.FirstSubmissionDate.HasValue);

                            if (date.DayOfWeek == DayOfWeek.Friday)
                            {
                                dayTickets = dayTickets.Where(x => x.FirstSubmissionDate.Value.Date >= date && x.FirstSubmissionDate < date.AddDays(3));
                            }
                            else
                            {
                                dayTickets = dayTickets.Where(x => x.FirstSubmissionDate.Value.Date == date);
                            }

                            var weekNumber = dayIndex / 7;
                            var dayNumber = dayIndex % 7;
                            return new ProfileAccomplishments.DailyData
                            {
                                Productivity = _scoreCalculator.Calculate(dayTickets, JiraConstants.RcTaskStatuses.Approved),
                                Quality = _ftarCalculator.CalculateActualValue(dayTickets, startDate, false),
                                PlannedProductivity = weeklyPlan.Value[weekNumber].Week[dayNumber].ScoreTarget
                            };
                        })
                        .Where(dailyData => dailyData != null)
                        .ToList()
                }
            };
        }

        private IList<ProfileAccomplishments.ModuleData> GetModuleDistribution(
            IList<RcTask> rcTickets,
            DateTime startDate,
            int weeksPast)
        {
            var listModuleDistribution = new List<ProfileAccomplishments.ModuleData>();
            rcTickets.GroupBy(x => x.Module).ToList().ForEach(moduleData =>
            {
                listModuleDistribution.Add(new ProfileAccomplishments.ModuleData
                {
                    Module = moduleData.Key,
                    ModuleTotalAverageFtar = _ftarCalculator.CalculateActualValue(moduleData, startDate, false)
                });
            });

            Enumerable.Range(0, weeksPast + 1).
                ToList().
                ForEach(
                    weekIndex =>
                    {
                        var weekTickets = rcTickets
                            .Where(x => x.FirstSubmissionDate.HasValue)
                            .Where(x =>
                                x.FirstSubmissionDate.Value.Date >= startDate.AddDays(weekIndex * 7)
                                && x.FirstSubmissionDate.Value.Date < startDate.AddDays((weekIndex + 1) * 7));

                        listModuleDistribution.ForEach(moduelData =>
                        {
                            var records = weekTickets.Where(x => x.Module == moduelData.Module).ToList();
                            moduelData.ScoreDistribution.Add(_scoreCalculator.Calculate(records, JiraConstants.RcTaskStatuses.Approved));
                            moduelData.QualityDistribution.Add(_ftarCalculator.CalculateActualValue(records, startDate, false));
                        });
                    });
            return listModuleDistribution;
        }
    }
}
