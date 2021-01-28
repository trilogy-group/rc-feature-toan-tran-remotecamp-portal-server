using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    class ProfileHardestProblemService : IProfileHardestProblemService
    {
        private readonly IProfileService _profileService;
        private readonly IHardestProblemService _hardestProblemService;
        private readonly IRcTaskLoader _rcTaskLoader;

        public ProfileHardestProblemService(IProfileService profileService,
            IHardestProblemService hardestProblemService,
            IRcTaskLoader rcTaskLoader)
        {
            _profileService = profileService;
            _hardestProblemService = hardestProblemService;
            _rcTaskLoader = rcTaskLoader;
        }

        public async Task<ServiceValueResponse<IList<ProfileHardestProblem>>> GetAllAsync(string email)
        {
            var profileResponse = await _profileService.GetAsync(email);

            if (!profileResponse.IsSuccess)
            {
                return ServiceValueResponse<IList<ProfileHardestProblem>>.NotFound($"User with email {email} was not found");
            }
            var profile = profileResponse.Value;

            var rcTasks = await _rcTaskLoader.LoadAsync(profile);

            var hardestProblemsByDay = _hardestProblemService.GetHardestProblemsByDay(rcTasks, profile);
            
            var totalCountOfFailures = hardestProblemsByDay
                .SelectMany(x => x.Items)
                .Where(x => !x.Resolved)
                .Sum(x => x.FailedIn.Count);

            var problems = hardestProblemsByDay
                .SelectMany(x => x.Items)
                .Where(x => !x.Resolved)
                .GroupBy(x => x.JiraKey, x => x.FailedIn)
                .Select(x =>
                {
                    var profileHardestProblem =
                        hardestProblemsByDay.SelectMany(y => y.Items).First(y => y.JiraKey == x.Key);

                    var failedInTickets = x.SelectMany(y => y).ToList();

                    var failedInJql = $"project = REM and key in ({string.Join(",", failedInTickets.Select(y => y.JiraKey))})";

                    return new ProfileHardestProblem
                    {
                        JiraKey = profileHardestProblem.JiraKey,
                        Summary = profileHardestProblem.Summary,
                        FailedInJiraLink =
                            $"{BusinessConstants.CrossoverJiraServerUrl}/issues/?jql={HttpUtility.UrlEncode(failedInJql)}",
                        Resolved = false,
                        StackRank = (double) failedInTickets.Count / totalCountOfFailures,
                        FailedIn = failedInTickets
                    };
                })
                .OrderByDescending(x => x.StackRank);

            var top3StackRanks = problems
                .Select(x => x.StackRank)
                .Distinct()
                .OrderByDescending(x => x)
                .Take(3);

            var hardestProblems = problems
                .Where(x => top3StackRanks.Any(topStackRank => x.StackRank == topStackRank))
                .ToList();
            
            return ServiceValueResponse<IList<ProfileHardestProblem>>.Success(hardestProblems);
        }
    }
}
