using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Octokit;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Infrastructure.GitHub;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Core.Test.Common;
using RemoteCamp.Portal.Core.Utils;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Services
{
    public class ProfileCrnFindingServiceTest : UnitTestBase
    {
        private readonly ProfileCrnFindingService _profileCrnFindingService;

        public ProfileCrnFindingServiceTest()
        {
            _profileCrnFindingService = ServiceProvider.GetService<ProfileCrnFindingService>();
        }

        [Fact]
        public async Task GetAsync_UsersExists_ReturnsProfile()
        {
            const string CrnRiqb = "RIQB-177";
            var utcNow = DateTime.UtcNow.Date;
            var startDate = new DateTime(2019, 6, 17);
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

            var rcTasks = new List<RcTask>
            {
                new RcTask
                {
                    JiraKey = "REM-1",
                    Summary= "Summary REM-1",
                    Status = JiraConstants.RcTaskStatuses.Approved,
                    SubmissionUrl = "https://github.com/trilogy-group/repo1/pull/1",
                    FailedIqbs = new List<RiqbItem> { riqbItems[0] }
                },
                new RcTask
                {
                    JiraKey = "REM-2",
                    Summary = "Summary REM-2",
                    SubmissionUrl = "https://github.com/trilogy-group/repo1/pull/2",
                    Reviews = new List<RcReview>
                    {
                        new RcReview
                        {
                            JiraKey = "REM-3"
                        }
                    }
                },
                new RcTask
                {
                    JiraKey = "REM-3",
                    Summary = "Summary REM-3",
                    Ftar = false,
                    SubmissionUrl = "https://github.com/trilogy-group/repo1/pull/3"
                }
            };

            var rcReviews = new List<RcReview>
            {
                new RcReview
                {
                    JiraKey = "REM-3",
                    FailedIqbs = new List<RiqbItem> { riqbItems[0], riqbItems[1] },
                }
            };


            var pullRequestComments = new List<PullRequestReviewComment>
            {
                new PullRequestReviewCommentBuilder { Body = CreateCrnCommentText("exclamation: comment1", "http://link1") }.Build(),
                new PullRequestReviewCommentBuilder { Body = CreateCrnCommentText("exclamation: comment1", "http://link1") }.Build(),
                new PullRequestReviewCommentBuilder { Body = CreateCrnCommentText("no_entry_sign: comment2", "http://link2") }.Build()
            };
            
            var profile = new Profile
            {
                StartDate = startDate,
                Status = "RC Active"
            };
            ServiceProvider.GetMock<IProfileService>()
                            .Setup(x => x.GetAsync(jiraUser.Email)).ReturnsAsync(ServiceValueResponse<Profile>.Success(profile));
            ServiceProvider.GetMock<IJiraUserRepository>()
                .Setup(x => x.GetByEmailAsync(jiraUser.Email, JiraUserLoadOptions.None)).ReturnsAsync(jiraUser);
            var requestDateRange = new Range<DateTime>(utcNow.AddDays(-28), utcNow.AddDays(1));

            ServiceProvider.GetMock<IRcTaskJiraRepository>()
                .Setup(x => x.FindFailedByAssigneeAndDatesAsync(jiraUser.AccountId, requestDateRange, RcTaskLoadOptions.All)).ReturnsAsync(rcTasks);

            ServiceProvider.GetMock<IRcReviewJiraRepository>()
                .Setup(x => x.FindByRcTaskAsync("REM-2")).ReturnsAsync(rcReviews);

            ServiceProvider.GetMock<IPullRequestRepository>()
                .Setup(
                    x => x.GetAllComments(
                        new GitHubPullRequestReference
                        {
                            Owner = "trilogy-group",
                            Repository = "repo1",
                            Number = 2
                        }))
                .ReturnsAsync(pullRequestComments);

            var result = await _profileCrnFindingService.GetAllAsync(jiraUser.Email);

            result.ShouldNotBeNull();
            result.IsSuccess.ShouldBeTrue();

            var crnFindings = result.Value;
            this.ShouldSatisfyAllConditions(
                () => crnFindings.Count.ShouldBe(2),
                () => crnFindings.FirstOrDefault(x => x.Link == "http://link1").ShouldNotBeNull(),
                () => crnFindings.FirstOrDefault(x => x.Link == "http://link1").FailedIn.Count.ShouldBe(1),
                () => crnFindings.FirstOrDefault(x => x.Link == "http://link1").FailedIn[0].JiraKey.ShouldBe("REM-2"),
                () => crnFindings.FirstOrDefault(x => x.Link == "http://link1").FailedIn[0].Summary.ShouldBe("Summary REM-2"),

                () => crnFindings.FirstOrDefault(x => x.Link == "http://link2").ShouldNotBeNull(),
                () => crnFindings.FirstOrDefault(x => x.Link == "http://link2").FailedIn.Count.ShouldBe(1),
                () => crnFindings.FirstOrDefault(x => x.Link == "http://link2").FailedIn[0].JiraKey.ShouldBe("REM-2"),
                () => crnFindings.FirstOrDefault(x => x.Link == "http://link2").FailedIn[0].Summary.ShouldBe("Summary REM-2")
            );
        }

        private string CreateCrnCommentText(string summary, string link)
        {
            return string.Format(
                @"**{0}**
[More details]({1})",
                summary,
                link);
        }
    }
}
