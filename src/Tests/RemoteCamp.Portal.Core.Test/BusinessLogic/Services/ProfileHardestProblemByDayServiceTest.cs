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
    public class ProfileHardestProblemByDayServiceTest : UnitTestBase
    {
        private readonly ProfileHardestProblemByDayService _profileHardestProblemByDayService;

        public ProfileHardestProblemByDayServiceTest()
        {
            _profileHardestProblemByDayService = ServiceProvider.GetService<ProfileHardestProblemByDayService>();
        }

        [Fact]
        public async Task GetAsync_UsersExistsAndHaveIqbFailed_ReturnsProfileHardestProblemByDayObject()
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
                new ProfileHardestProblemByDay()
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
            var result = await _profileHardestProblemByDayService.GetAllAsync(email);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.IsSuccess.ShouldBeTrue(),
                () => result.Value.ShouldBeSameAs(hardestProblemsByDay)
            );
        }
    }
}