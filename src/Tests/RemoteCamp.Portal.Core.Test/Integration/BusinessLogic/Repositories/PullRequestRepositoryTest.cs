using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.GitHub;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.Integration.BusinessLogic.Repositories
{
    public class PullRequestRepositoryTest
    {
        [Fact]
        public async void Test()
        {
            var repository = new PullRequestRepository(new GitHubClientAdapter(TestApplicationOptionsFactory.Default.Create()));
            var pullRequestReference = new GitHubPullRequestReference()
            {
                Owner = "trilogy-group",
                Repository = "rc-cc-seematai-km-all-projects",
                Number = 4
            };
            var result = await repository.GetAllComments(pullRequestReference);
            result.ShouldNotBeNull();
        }
    }
}
