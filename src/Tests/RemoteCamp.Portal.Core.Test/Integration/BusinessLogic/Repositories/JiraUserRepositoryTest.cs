using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.Integration.BusinessLogic.Repositories
{
    public class JiraUserRepositoryTest
    {
        [Fact]
        public async void FindByCompanyEmailAsync_EmailExists_ReturnsUser()
        {
            var repository = new JiraUserRepository(new JiraClientAdapter(TestApplicationOptionsFactory.Default.Create()));

            var user = await repository.GetByEmailAsync("alex.netrebskiy@aurea.com");

            this.ShouldSatisfyAllConditions(
                () => user.ShouldNotBeNull(),
                () => user.Email.ShouldBe("alex.netrebskiy@aurea.com"),
                () => user.DisplayName.ShouldBe("Alex Netrebskiy"),
                () => user.AccountId.ShouldBe("5c9219c36e4d1d2c5d2edd76"),
                () => user.IsActive.ShouldBeTrue()
                );
        }

        [Fact]
        public async void FindByCompanyEmailAsync_EmailNotExists_ReturnsNull()
        {
            var repository = new JiraUserRepository(new JiraClientAdapter(TestApplicationOptionsFactory.Default.Create()));

            var user = await repository.GetByEmailAsync("notexists@mail.test");

            this.ShouldSatisfyAllConditions(
                () => user.ShouldBeNull());
        }

        [Fact]
        public async void GetByEmailAsync_UsersExistsAndGroupsRequested_ReturnsUserAndGroups()
        {
            var repository = new JiraUserRepository(new JiraClientAdapter(TestApplicationOptionsFactory.Default.Create()));

            var user = await repository.GetByEmailAsync("alex.netrebskiy@aurea.com", JiraUserLoadOptions.Groups);

            this.ShouldSatisfyAllConditions(
                () => user.ShouldNotBeNull(),
                () => user.Email.ShouldBe("alex.netrebskiy@aurea.com"),
                () => user.DisplayName.ShouldBe("Alex Netrebskiy"),
                () => user.AccountId.ShouldBe("5c9219c36e4d1d2c5d2edd76"),
                () => user.IsActive.ShouldBeTrue(),
                () => user.Groups.Count.ShouldBeGreaterThan(0),
                () => user.Groups.ShouldContain(x => x == "RemoteCamp-QE")
            );
        }
    }
}
