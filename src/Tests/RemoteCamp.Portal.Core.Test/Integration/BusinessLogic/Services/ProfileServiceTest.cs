using System;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.Integration.BusinessLogic.Services
{
    public class ProfileServiceTest
    {
        [Fact]
        public async Task GetAsync_UsersExists_ReturnsProfile()
        {
            var applicationOption = TestApplicationOptionsFactory.Default.Create();
                        var service = new ProfileService(new ErTicketRepository(new JiraClientAdapter(applicationOption), applicationOption));
            var result = await service.GetAsync("nwachukwu.okafor@aurea.com");

            result.ShouldNotBeNull();
            var profile = result.Value;
            this.ShouldSatisfyAllConditions(
                () => profile.ShouldNotBeNull(),
                () => profile.StartDate.ShouldNotBeNull(),
                () => profile.StartDate.Value.ShouldBeGreaterThan(new DateTime(2019, 1,1)),
                () => profile.CompanyEmail.ShouldBe("nwachukwu.okafor@aurea.com"),
                () => profile.Pipeline.ShouldBe("C# (.NET) Software Engineer"));

        }
    }
}
