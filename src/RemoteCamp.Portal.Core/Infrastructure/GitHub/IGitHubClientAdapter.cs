using Octokit;

namespace RemoteCamp.Portal.Core.Infrastructure.GitHub
{
    public interface IGitHubClientAdapter
    {
        IGitHubClient Client { get; }
    }
}