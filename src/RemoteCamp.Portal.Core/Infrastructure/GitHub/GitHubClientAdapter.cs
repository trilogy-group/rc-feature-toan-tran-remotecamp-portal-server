using Octokit;
using RemoteCamp.Portal.Core.Infrastructure.Common;
using RemoteCamp.Portal.Core.Infrastructure.Data;

namespace RemoteCamp.Portal.Core.Infrastructure.GitHub
{
    public class GitHubClientAdapter : IGitHubClientAdapter
    {
        public GitHubClientAdapter(ApplicationOptions applicationOptions)
        {
            Client = new GitHubClient(new ProductHeaderValue(InfrastructureConstants.ApplicationName))
            {
                Credentials = new Credentials(applicationOptions.GithubAccessToken)
            };
        }

        public IGitHubClient Client { get; }
    }
}
