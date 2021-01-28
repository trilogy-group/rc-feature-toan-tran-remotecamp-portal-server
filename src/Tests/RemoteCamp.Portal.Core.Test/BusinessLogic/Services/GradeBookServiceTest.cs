using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using RemoteCamp.Portal.Core.Utils;
using RemoteCamp.Portal.Core.Test.Common;
using Shouldly;
using Xunit;
using static RemoteCamp.Portal.Core.Infrastructure.Jira.JiraConstants;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Core.Database.Model;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Services
{
    public class GradeBookServiceTest : UnitTestBase
    {
        private readonly GradeBookService _gradeBookService;

        public GradeBookServiceTest()
        {
            _gradeBookService = ServiceProvider.GetService<GradeBookService>();
        }

        [Fact]
        public async Task GetAllAsync_UsersExists_ReturnsGradeBook()
        {
            const string CrnRiqb = "RIQB-177";
            var utcNow = DateTime.UtcNow.Date;

            var jiraUser = new JiraUser
            {
                Email = "john.snow@mail.test",
                AccountId = "john.snow"
            };

            var riqbItems = new List<RiqbItem>
            {
                new RiqbItem
                {
                    JiraKey = CrnRiqb,
                    Summary = "Summary1",
                },
                new RiqbItem
                {
                    JiraKey = "RIQB-2",
                    Summary = "Summary2"
                }
            };
            var user = CreateUserObject();
            var rcTasks = GetRcTasks(riqbItems);

            ServiceProvider.GetMock<IJiraUserRepository>()
                .Setup(x => x.GetByEmailAsync(jiraUser.Email, JiraUserLoadOptions.None)).ReturnsAsync(jiraUser);
            var requestDateRange = new Range<DateTime>(utcNow.AddDays(-28), utcNow.AddDays(1));

            ServiceProvider.GetMock<IRcTaskJiraRepository>()
                .Setup(x => x.FindAllAsync(RcTaskLoadOptions.Assignee |
                    RcTaskLoadOptions.Status |
                    RcTaskLoadOptions.FirstSubmissionDate |
                    RcTaskLoadOptions.Ftar |
                    RcTaskLoadOptions.Score)).ReturnsAsync(rcTasks);

            ServiceProvider.GetMock<IScoreCalculator>()
                .Setup(x => x.Calculate(rcTasks, RcTaskStatuses.Approved)).Returns(10);

            ServiceProvider.GetMock<IScoreCalculator>()
                .Setup(x => x.Calculate(rcTasks, RcTaskStatuses.InReview)).Returns(10);

            ServiceProvider.GetMock<IScoreCalculator>()
                .Setup(x => x.Calculate(rcTasks, RcTaskStatuses.InProgress)).Returns(10);

            ServiceProvider.GetMock<IProfileService>()
                .Setup(x => x.GetAllActiveAsync())
                .ReturnsAsync(CreateProfileObject());

            ServiceProvider.GetMock<IUserService>()
                .Setup(x => x.GetOrCreateByEmailAsync("john.snow@mail.test")).ReturnsAsync(new ServiceValueResponse<User> { Value = user });

            var result = await _gradeBookService.GetAllAsync();
            result.ShouldNotBeNull();
            result.IsSuccess.ShouldBeTrue();
            this.ShouldSatisfyAllConditions(
                () => result.Value.GradeBook[0].Manager.ShouldBe("Absc1234"),
                () => result.Value.GradeBook[0].Pipeline.ShouldBe("C# (.NET) Software Engineer"),
                () => result.Value.GradeBook[0].QualitySummary.ShouldNotBeNull(),
                () => result.Value.GradeBook[0].QualitySummary.Approved.ShouldBe(null),
                () => result.Value.GradeBook[0].QualitySummary.ApprovedAndInReview.ShouldBe(null),
                () => result.Value.GradeBook[0].ScoreSummary.InReview.ShouldBe(10),
                () => result.Value.GradeBook[0].ScoreSummary.InProgress.ShouldBe(10),
                () => result.Value.GradeBook[0].ScoreSummary.Approved.ShouldBe(10));
        }

        private static List<RcTask> GetRcTasks(List<RiqbItem> riqbItems)
        {
            return new List<RcTask>
            {
                new RcTask
                {
                    JiraKey = "REM-1",
                    Summary= "absc1234",
                    Status = JiraConstants.RcTaskStatuses.Approved,
                    FailedIqbs = new List<RiqbItem> { riqbItems[0] },
                    Assignee = new JiraUserValue
                    {
                        AccountId = "absc1234",
                        DisplayName = "absc1234"
                    },
                    Ftar=true,
                    Score=1
                },
                new RcTask
                {
                    JiraKey = "REM-1",
                    Summary= "absc1234",
                    Status = JiraConstants.RcTaskStatuses.Approved,
                    FailedIqbs = new List<RiqbItem> { riqbItems[0] },
                    Assignee = new JiraUserValue
                    {
                        AccountId = "absc1234",
                        DisplayName = "absc1234"
                    },
                    Ftar=true,
                    Score=1
                },
                new RcTask
                {
                    JiraKey = "REM-1",
                    Summary= "absc1234",
                    Status = JiraConstants.RcTaskStatuses.Approved,
                    FailedIqbs = new List<RiqbItem> { riqbItems[0] },
                    Assignee = new JiraUserValue
                    {
                        AccountId = "absc1234",
                        DisplayName = "absc1234"
                    },
                    Ftar=true,
                    Score=1
                },
                new RcTask
                {
                    JiraKey = "REM-2",
                    Summary = "absc1234",
                    Status = JiraConstants.RcTaskStatuses.InProgress,
                    Reviews = new List<RcReview>
                    {
                        new RcReview
                        {
                            JiraKey = "REM-3"
                        }
                    },
                    Assignee = new JiraUserValue
                    {
                        AccountId = "absc1234",
                        DisplayName = "absc1234"
                    },
                    Ftar=true,
                    Score=2
                },
                new RcTask
                {
                    JiraKey = "REM-3",
                    Summary = "absc1234",
                    Status = JiraConstants.RcTaskStatuses.InReview,
                    Ftar = false,
                    Assignee = new JiraUserValue
                    {
                        AccountId = "absc1234",
                        DisplayName = "absc1234"
                    },
                    Score=3
                },
                new RcTask
                {
                    JiraKey = "REM-3",
                    Summary = "absc1234",
                    Status = JiraConstants.RcTaskStatuses.InReview,
                    Ftar = false,
                    Assignee = new JiraUserValue
                    {
                        AccountId = "absc1234",
                        DisplayName = "absc1234"
                    },
                    Score=3
                },
                new RcTask
                {
                    JiraKey = "REM-3",
                    Summary = "absc1234",
                    Status = JiraConstants.RcTaskStatuses.InReview,
                    Ftar = false,
                    Assignee = new JiraUserValue
                    {
                        AccountId = "absc1234",
                        DisplayName = "absc1234"
                    },
                    Score=3
                }

            };
        }

        private static User CreateUserObject()
        {
            return new User
            {
                Id = 1,
                CreatedAt = DateTime.UtcNow,
                Email = "gaurav.thakur@aurea.com"
            };
        }

        private static ServiceValueResponse<IList<Profile>> CreateProfileObject()
        {
            return ServiceValueResponse<IList<Profile>>.Success(new List<Profile>
            {
                new Profile
                {
                    ManagerJiraUser = new JiraUserValue
                    {
                        AccountId = "absc1234",
                        DisplayName = "Absc1234",
                    },
                    DeckUrl = "http://test.deckurl",
                    Pipeline = "C# (.NET) Software Engineer",
                    JiraId = "absc1234",
                    XoId = 1,
                    StartDate = DateTime.Now,
                    Status = "RC-Active",
                    Name = "absc1234",
                    TmsUrl = "http://tms.url",
                    CompanyEmail = "john.snow@mail.test"
                }
            });
        }
    }
}
