using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Octokit;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.GitHub;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Core.Utils;
using RemoteU.Component.NoSqlClient;
using static RemoteCamp.Portal.Core.Infrastructure.Jira.JiraConstants;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    class ProfileCrnFindingService : IProfileCrnFindingService
    {
        private const string NoEntrySign = "no_entry_sign";
        private const string ExclamationSign = "exclamation";

        private readonly IRcTaskJiraRepository _rcTaskRepository;
        private readonly IRcReviewJiraRepository _rcReviewRepository;
        private readonly IJiraUserRepository _jiraUserRepository;
        private readonly IPullRequestRepository _pullRequestRepository;
        private readonly IProfileService _profileService;
        private readonly IErDocumentRepository _erDocumentRepository;

        public ProfileCrnFindingService(
            IRcTaskJiraRepository rcTaskRepository,
            IRcReviewJiraRepository rcReviewRepository,
            IJiraUserRepository jiraUserRepository,
            IPullRequestRepository pullRequestRepository,
            IProfileService profileService,
            IErDocumentRepository erDocumentRepository)
        {
            _rcTaskRepository = rcTaskRepository;
            _rcReviewRepository = rcReviewRepository;
            _jiraUserRepository = jiraUserRepository;
            _pullRequestRepository = pullRequestRepository;
            _profileService = profileService;
            _erDocumentRepository = erDocumentRepository;
        }

        public async Task<ServiceValueResponse<IList<CrnFinding>>> GetAllAsync(string email)
        {
            var profileResponse = await _profileService.GetAsync(email);
            if (!profileResponse.IsSuccess)
            {
                return ServiceValueResponse<IList<CrnFinding>>.FromErrors(profileResponse.Errors);
            }

            var profile = profileResponse.Value;
            var rcTickets = new List<RcTask>();
            if (profile.Status != ErTicketStatuses.RcActive)
            {
                var document = await _erDocumentRepository.GetErDocumentById(profile.JiraId);
                if (document != null)
                {
                    rcTickets.AddRange(document.GetRcTask());
                }
            }
            else
            {
                var jiraUser = await _jiraUserRepository.GetByEmailAsync(email);
                if (jiraUser == null)
                {
                    return ServiceValueResponse<IList<CrnFinding>>.NotFound($"User with email {email} was not found");
                }
                var utcNow = DateTime.UtcNow.Date;
                rcTickets = await _rcTaskRepository.FindFailedByAssigneeAndDatesAsync(
                    jiraUser.AccountId,
                    new Range<DateTime>(utcNow.AddDays(-BusinessConstants.NumberOfDaysInRemoteCamp), utcNow.AddDays(1)));

                rcTickets.Where(x => !x.Reviews.IsNullOrEmpty() && GitHubPullRequestReference.TryParse(x.SubmissionUrl, out var gitHubPullRequest))
                    .AsParallel()
                    .ForAll(x => x.Reviews = AsyncUtil.RunSync(() => _rcReviewRepository.FindByRcTaskAsync(x.JiraKey)));
            }

            var crnFindings = await GetCrnFindingsAsync(rcTickets);

            return ServiceValueResponse<IList<CrnFinding>>.Success(crnFindings);
        }

        private async Task<List<CrnFinding>> GetCrnFindingsAsync(List<RcTask> rcTickets)
        {
            var crnFindings = new List<CrnFinding>();
            foreach (var rcTicket in rcTickets)
            {
                if (!GitHubPullRequestReference.TryParse(rcTicket.SubmissionUrl, out var gitHubPullRequest))
                {
                    continue;
                }

                var isCrnFailed = (rcTicket.FailedIqbs ?? Enumerable.Empty<RiqbItem>()).Concat(
                        rcTicket.Reviews == null
                            ? Enumerable.Empty<RiqbItem>()
                            : rcTicket.Reviews.SelectMany(x => x.FailedIqbs))
                    .Any(x => BusinessConstants.CrnRiqbs.Contains(x.JiraKey, StringComparer.OrdinalIgnoreCase));

                if (!isCrnFailed)
                {
                    continue;
                }

                var comments = await _pullRequestRepository.GetAllComments(gitHubPullRequest) ?? Enumerable.Empty<PullRequestReviewComment>();
                var crnComments = comments.Where(x => x.Body.Contains(ExclamationSign) || x.Body.Contains(NoEntrySign));
                foreach (var crnComment in crnComments)
                {
                    var crnFindingLink = CrnCommentParser.GetLink(crnComment.Body);
                    var crnSummary = CrnCommentParser.GetSummary(crnComment.Body);
                    if (crnFindingLink == null || crnSummary == null)
                    {
                        continue;
                    }

                    var crnFinding = crnFindings.FirstOrDefault(x => x.Link == crnFindingLink);
                    if (crnFinding == null)
                    {
                        crnFinding = new CrnFinding
                        {
                            Summary = crnSummary,
                            Link = crnFindingLink
                        };

                        crnFindings.Add(crnFinding);
                    }

                    if (crnFinding.FailedIn.All(x => x.JiraKey != rcTicket.JiraKey))
                    {
                        crnFinding.FailedIn.Add(
                            new CrnFinding.FailedInIssue
                            {
                                JiraKey = rcTicket.JiraKey,
                                Summary = rcTicket.Summary
                            });
                    }
                }
            }

            return crnFindings;
        }
    }
}
