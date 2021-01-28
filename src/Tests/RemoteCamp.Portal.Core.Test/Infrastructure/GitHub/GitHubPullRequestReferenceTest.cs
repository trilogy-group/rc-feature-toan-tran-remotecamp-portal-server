using RemoteCamp.Portal.Core.Infrastructure.GitHub;
using RemoteCamp.Portal.Core.Test.Common;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.Infrastructure.GitHub
{
    public class GitHubPullRequestReferenceTest : UnitTestBase
    {
        [Fact]
        public void Parse_CorrectUrl_ReturnsParsedValue()
        {
            var result = GitHubPullRequestReference.TryParse("https://github.com/trilogy-group/rc-cc-seematai-km-all-projects/pull/44", out var gitHubPullRequest);

            result.ShouldBeTrue();
            gitHubPullRequest.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => gitHubPullRequest.Owner.ShouldBe("trilogy-group"),
                () => gitHubPullRequest.Repository.ShouldBe("rc-cc-seematai-km-all-projects"),
                () => gitHubPullRequest.Number.ShouldBe(44)
                );
        }

        [Fact]
        public void Parse_CorrectUrlWithFilesAtTheEnd_ReturnsParsedValue()
        {
            var result = GitHubPullRequestReference.TryParse("https://github.com/trilogy-group/rc-cc-seematai-km-all-projects/pull/44/files", out var gitHubPullRequest);

            result.ShouldBeTrue();
            gitHubPullRequest.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => gitHubPullRequest.Owner.ShouldBe("trilogy-group"),
                () => gitHubPullRequest.Repository.ShouldBe("rc-cc-seematai-km-all-projects"),
                () => gitHubPullRequest.Number.ShouldBe(44)
            );
        }

        [Fact]
        public void Parse_IncorrectCorrectUrl_ReturnsFalse()
        {
            var result = GitHubPullRequestReference.TryParse("https://github.com/trilogy-group/rc-cc-seematai-km-all-projects/pull/", out var gitHubPullRequest);

            result.ShouldBeFalse();
            gitHubPullRequest.ShouldBeNull();
        }
    }
}
