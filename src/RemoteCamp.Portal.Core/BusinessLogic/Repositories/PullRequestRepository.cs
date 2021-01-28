using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Octokit;
using RemoteCamp.Portal.Core.Infrastructure.GitHub;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    class PullRequestRepository : IPullRequestRepository
    {
        private readonly IGitHubClientAdapter _gitHubClientAdapter;

        public PullRequestRepository(IGitHubClientAdapter gitHubClientAdapter)
        {
            _gitHubClientAdapter = gitHubClientAdapter;
        }

        public async Task<IList<PullRequestReviewComment>> GetAllComments(GitHubPullRequestReference pullRequest)
        {
            var comments = await _gitHubClientAdapter.Client.PullRequest.ReviewComment.GetAll(pullRequest.Owner, pullRequest.Repository, pullRequest.Number);
            return comments.ToList();
        }
    }
}
