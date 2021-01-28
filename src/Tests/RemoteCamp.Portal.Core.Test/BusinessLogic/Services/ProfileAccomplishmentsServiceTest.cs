using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Common;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Core.Test.Common;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Services
{
    public class ProfileAccomplishmentsServiceTest : UnitTestBase
    {
        private readonly ProfileAccomplishmentsService _profileAccomplishmentsService;

        public ProfileAccomplishmentsServiceTest()
        {
            ServiceProvider.SetInstance<IFtarCalculator>(new FtarCalculator());
            ServiceProvider.SetInstance<IScoreCalculator>(new ScoreCalculator());
            ServiceProvider.SetInstance<IQualityTargetProvider>(ServiceProvider.GetService<QualityTargetProvider>());

            _profileAccomplishmentsService = ServiceProvider.GetService<ProfileAccomplishmentsService>();
        }

        [Fact]
        public async Task GetAsync_UsersExists_ReturnsProfile()
        {
            var utcNowDate = new DateTime(2019, 7, 2);
            var startDate = new DateTime(2019, 6, 17);

            var jiraUser = new JiraUser
            {
                Email = "john.snow@mail.test",
                AccountId = "john.snow",
            };

            var rcTasks = new List<RcTask>
            {
                new RcTask
                {
                    Assignee = new JiraUserValue
                    {
                        AccountId = jiraUser.AccountId
                    },
                    Ftar = true,
                    Score = 1,
                    FirstSubmissionDate = startDate,
                    Status = JiraConstants.RcTaskStatuses.Approved
                },
                new RcTask
                {
                    Assignee = new JiraUserValue
                    {
                        AccountId = jiraUser.AccountId
                    },
                    Ftar = false,
                    Score = 1,
                    FirstSubmissionDate = startDate.AddDays(14),
                    Status = JiraConstants.RcTaskStatuses.Approved
                },
                new RcTask
                {
                    Assignee = new JiraUserValue
                    {
                        AccountId = jiraUser.AccountId
                    },
                    Score = 1,
                    FirstSubmissionDate = startDate.AddDays(15),
                    Status = JiraConstants.RcTaskStatuses.InReview
                },
                new RcTask
                {
                    Assignee = new JiraUserValue
                    {
                        AccountId = jiraUser.AccountId
                    },
                    Score = 1,
                    Ftar = true,
                    FirstSubmissionDate = startDate.AddDays(16),
                    Status = JiraConstants.RcTaskStatuses.Approved
                },
                new RcTask
                {
                    Assignee = new JiraUserValue
                    {
                        AccountId = jiraUser.AccountId
                    },
                    Score = 1,
                    Ftar = false,
                    FirstSubmissionDate = startDate.AddDays(17),
                    Status = JiraConstants.RcTaskStatuses.Approved
                },
                new RcTask
                {
                    Assignee = new JiraUserValue
                    {
                        AccountId = jiraUser.AccountId
                    },
                    Score = 1,
                    Ftar = true,
                    FirstSubmissionDate = startDate.AddDays(18),
                    Status = JiraConstants.RcTaskStatuses.Approved
                },
                new RcTask
                {
                    Assignee = new JiraUserValue
                    {
                        AccountId = jiraUser.AccountId
                    },
                    Ftar = true,
                    Score = 1,
                    FirstSubmissionDate = startDate.AddDays(19),
                    Status = JiraConstants.RcTaskStatuses.Approved
                },
            };

            var profile = new Profile
            {
                StartDate = startDate,
                Status = "RC Active"
            };

            MockTimeService(utcNowDate);
            ServiceProvider.GetMock<IProfileService>()
                .Setup(x => x.GetAsync(jiraUser.Email)).ReturnsAsync(ServiceValueResponse<Profile>.Success(profile));
            ServiceProvider.GetMock<IJiraUserRepository>()
                .Setup(x => x.GetByEmailAsync(jiraUser.Email, JiraUserLoadOptions.None)).ReturnsAsync(jiraUser);
            ServiceProvider.GetMock<IRcTaskJiraRepository>()
                .Setup(x => x.FindByAssigneeAsync(jiraUser.AccountId, RcTaskLoadOptions.FirstSubmissionDate
                                                                                     | RcTaskLoadOptions.Status
                                                                                     | RcTaskLoadOptions.Ftar
                                                                                     | RcTaskLoadOptions.Score)).ReturnsAsync(rcTasks);
            ServiceProvider.GetMock<IWeeklyPlanService>()
                .Setup(x => x.GetAllAsync(jiraUser.Email))
                .ReturnsAsync(ServiceValueResponse<IList<WeeklyPlanWeek>>.Success(GenerateWeeklyPlanData()));

            var result = await _profileAccomplishmentsService.GetAsync(jiraUser.Email);

            result.ShouldNotBeNull();
            result.IsSuccess.ShouldBeTrue();

            var dailyMetrics = result.Value;
            this.ShouldSatisfyAllConditions(
                () => dailyMetrics.ScoreSummary.Approved.ShouldBe(6),
                () => dailyMetrics.ScoreSummary.InReview.ShouldBe(1),
                () => dailyMetrics.ScoreSummary.TargetForToday.ShouldBe(15),
                () => dailyMetrics.QualitySummary.Approved.Value.ShouldBe(0.66d, 0.01),
                () => dailyMetrics.QualitySummary.TargetForToday.ShouldBe(1.0),
                () => dailyMetrics.GraduationQualitySummary.Approved.Value.ShouldBe(0.6d),
                () => dailyMetrics.GraduationQualitySummary.TargetForToday.ShouldBe(1d),
                () => dailyMetrics.Daily.Count.ShouldBe(12),
                () => dailyMetrics.Daily[10].Productivity.ShouldBe(1),
                () => dailyMetrics.Daily[10].PlannedProductivity.ShouldBe(3.5),
                () => dailyMetrics.Daily[10].Quality.ShouldBe(0),
                () => dailyMetrics.Daily[11].Productivity.ShouldBe(0),
                () => dailyMetrics.Daily[11].PlannedProductivity.ShouldBe(3.5),
                () => dailyMetrics.Daily[11].Quality.ShouldBeNull(),

                () => dailyMetrics.Weekly.Count.ShouldBe(3),
                () => dailyMetrics.Weekly[0].Productivity.ShouldBe(1),
                () => dailyMetrics.Weekly[0].Quality.ShouldBe(1d),
                () => dailyMetrics.Weekly[1].Productivity.ShouldBe(0),
                () => dailyMetrics.Weekly[1].Quality.ShouldBeNull(),
                () => dailyMetrics.Weekly[2].Productivity.ShouldBe(5),
                () => dailyMetrics.Weekly[2].Quality.ShouldBe(0.6d)
            );
        }

        private IList<WeeklyPlanWeek> GenerateWeeklyPlanData()
        {
            var weeks = new List<WeeklyPlanWeek>();

            for (var weekNumber = 1; weekNumber <= 4; weekNumber++)
            {
                var week = new WeeklyPlanWeek
                {
                    Id = weekNumber,
                    Approved = false,
                    Submitted = false,
                    WeekNumber = (StudyWeek)weekNumber,
                    UserId = 1,
                    Week = new List<WeeklyPlanDay>()
                };

                for (var dayNumber = 1; dayNumber <= 5; dayNumber++)
                {
                    var day = new WeeklyPlanDay
                    {
                        Id = dayNumber,
                        Day = ((DayOfWeek)dayNumber).ToString(),
                        ScoreTarget = 3.5,
                        Summary = null,
                        WeeklyPlanWeekId = week.Id
                    };

                    week.Week.Add(day);
                }

                weeks.Add(week);
            }

            return weeks;
        }
    }
}
