using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Core.Test.Common;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Services
{
    public class ProfileHardestProblemServiceTest : UnitTestBase
    {
        private readonly ProfileHardestProblemService _profileHardestProblemService;

        public ProfileHardestProblemServiceTest()
        {
            _profileHardestProblemService = ServiceProvider.GetService<ProfileHardestProblemService>();
        }

        [Fact]
        public async Task GetAsync_UsersExists_ReturnsProfile()
        {
            // Arrange
            var email = "jon.snow@mail.test";

            var rcTasks = new List<RcTask>
            {
                new RcTask
                {
                    JiraKey = "REM-1"
                }
            };

            var profile = new Profile
            {
                JiraId = "profileJiraId1"
            };

            var hardestProblemsByDay = new List<ProfileHardestProblemByDay>()
            {
                new ProfileHardestProblemByDay
                {
                    Items = new List<ProfileHardestProblem>
                    {
                        new ProfileHardestProblem
                        {
                            JiraKey = "riqb-1",
                            FailedIn = new List<ProfileHardestProblem.FailedInIssue>
                            {
                                new ProfileHardestProblem.FailedInIssue
                                {
                                    JiraKey = "rem-1"
                                }
                            }
                        },
                        new ProfileHardestProblem
                        {
                            JiraKey = "riqb-2",
                            Resolved = true,
                            FailedIn = new List<ProfileHardestProblem.FailedInIssue>
                            {
                                new ProfileHardestProblem.FailedInIssue
                                {
                                    JiraKey = "rem-2"
                                }
                            }
                        }
                    }
                },
                new ProfileHardestProblemByDay
                {
                    Items = new List<ProfileHardestProblem>
                    {
                        new ProfileHardestProblem
                        {
                            JiraKey = "riqb-1",
                            FailedIn = new List<ProfileHardestProblem.FailedInIssue>
                            {
                                new ProfileHardestProblem.FailedInIssue
                                {
                                    JiraKey = "rem-2"
                                }
                            }
                        }
                    }
                }
            };

            ServiceProvider.GetMock<IProfileService>()
                .Setup(x => x.GetAsync(email)).ReturnsAsync(ServiceValueResponse<Profile>.Success(profile));

            ServiceProvider.GetMock<IRcTaskLoader>()
                .Setup(x => x.LoadAsync(It.Is<Profile>(y => y.JiraId == profile.JiraId)))
                .ReturnsAsync(() => rcTasks);

            ServiceProvider.GetMock<IHardestProblemService>()
                .Setup(x => x.GetHardestProblemsByDay(
                    It.Is<List<RcTask>>(y => y.Count == 1),
                    It.Is<Profile>(y => y.JiraId == profile.JiraId)))
                .Returns(() => hardestProblemsByDay);

            // Act
            var result = await _profileHardestProblemService.GetAllAsync(email);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.IsSuccess.ShouldBeTrue(),
                () => result.Value.Count.ShouldBe(1),
                () => result.Value[0].JiraKey.ShouldBe(hardestProblemsByDay[0].Items[0].JiraKey),
                () => result.Value[0].StackRank.ShouldBe(1),
                () => result.Value[0].FailedInJiraLink.ShouldBe("https://crossover.atlassian.net/issues/?jql=project+%3d+REM+and+key+in+(rem-1%2crem-2)"),
                () => result.Value[0].FailedIn.ShouldNotBeNull(),
                () => result.Value[0].FailedIn.Count.ShouldBe(2),
                () => result.Value[0].FailedIn[0].JiraKey.ShouldBe(hardestProblemsByDay[0].Items[0].FailedIn[0].JiraKey)
            );
        }
    }
}
