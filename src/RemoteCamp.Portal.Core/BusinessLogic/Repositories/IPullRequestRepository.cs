using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;
using RemoteCamp.Portal.Core.Infrastructure.GitHub;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public interface IPullRequestRepository
    {
        Task<IList<PullRequestReviewComment>> GetAllComments(GitHubPullRequestReference pullRequest);
    }
}