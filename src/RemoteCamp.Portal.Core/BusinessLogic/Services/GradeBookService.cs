using System;
using System.Linq;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using static RemoteCamp.Portal.Core.Infrastructure.Jira.JiraConstants;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public class GradeBookService : IGradeBookService
    {
        private readonly IRcTaskJiraRepository _rcTaskRepository;
        private readonly IProfileService _profileService;
        private readonly IScoreCalculator _scoreCalculator;
        private readonly IFtarCalculator _ftarCalculator;
        private readonly IQualityTargetProvider _qualityTargetProvider;
        private readonly IJiraUserRepository _jiraUserRepository;

        public GradeBookService(IRcTaskJiraRepository rcTaskRepository,
            IProfileService profileService,
            IJiraUserRepository jiraUserRepository,
            IScoreCalculator scoreCalculator,
            IFtarCalculator ftarCalculator,
            IQualityTargetProvider qualityTargetProvider)
        {
            _rcTaskRepository = rcTaskRepository ?? throw new ArgumentNullException(nameof(rcTaskRepository));
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
            _jiraUserRepository = jiraUserRepository ?? throw new ArgumentNullException(nameof(jiraUserRepository));
            _scoreCalculator = scoreCalculator ?? throw new ArgumentNullException(nameof(scoreCalculator));
            _ftarCalculator = ftarCalculator ?? throw new ArgumentNullException(nameof(ftarCalculator));
            _qualityTargetProvider = qualityTargetProvider ?? throw new ArgumentNullException(nameof(qualityTargetProvider));;
        }

        public async Task<ServiceValueResponse<CachedGradeBook>> GetAllAsync()
        {
            var profilesResponse = await _profileService.GetAllActiveAsync();
            if (!profilesResponse.IsSuccess)
            {
                return ServiceValueResponse<CachedGradeBook>.FromErrors(profilesResponse.Errors);
            }

            var profiles = profilesResponse.Value;

            var rcTickets = await _rcTaskRepository.FindAllAsync(
                RcTaskLoadOptions.Assignee |
                RcTaskLoadOptions.Status |
                RcTaskLoadOptions.FirstSubmissionDate |
                RcTaskLoadOptions.Ftar |
                RcTaskLoadOptions.Score);

            var cachedGradeBook = new CachedGradeBook();
            foreach (var profile in profiles)
            {
                var jiraRcIckets = rcTickets.Where(x => x.Assignee.AccountId == profile.JiraId);
                var rcTicket = jiraRcIckets.FirstOrDefault();
                var shortName = rcTicket?.Assignee?.AccountId;

                if (string.IsNullOrWhiteSpace(shortName))
                {
                    var jiraUser = await _jiraUserRepository.GetByEmailAsync(profile.CompanyEmail);
                    shortName = jiraUser?.AccountId;
                }

                var startDate = profile.StartDate.Value.Date;
                var targetForToday = _scoreCalculator.CalculateDailyTarget(profile.StartDate.Value);
                var ultimateTarget = _scoreCalculator.CalculateDailyTarget(DateTime.Today.AddDays(-30));

                cachedGradeBook.GradeBook.Add(new GradeBook
                {
                    IcName = profile.IcName,
                    Email = profile.CompanyEmail,
                    IcNameShort = shortName,
                    RcXoId = profile.XoId,
                    Manager = profile.ManagerJiraUser?.DisplayName,
                    Pipeline = profile.Pipeline,
                    Start = startDate,
                    QualitySummary = new Quality
                    {
                        Approved = _ftarCalculator.CalculateGraduationValue(jiraRcIckets, profile.StartDate.Value, false),
                        ApprovedAndInReview = _ftarCalculator.CalculateGraduationValue(jiraRcIckets, profile.StartDate.Value, true),
                        TargetForToday = _qualityTargetProvider.GetActualTarget()
                    },
                    ScoreSummary = new Score
                    {
                        Approved = _scoreCalculator.Calculate(jiraRcIckets, RcTaskStatuses.Approved),
                        InProgress = _scoreCalculator.Calculate(jiraRcIckets, RcTaskStatuses.InProgress),
                        InReview = _scoreCalculator.Calculate(jiraRcIckets, RcTaskStatuses.InReview),
                        TargetForToday = targetForToday,
                        UltimateTarget = ultimateTarget
                    }
                });
            }
            cachedGradeBook.GradeBook = cachedGradeBook.GradeBook.OrderBy(x => x.Start).ToList();
            cachedGradeBook.CurrentDateTimeStamp = DateTime.UtcNow;
            return ServiceValueResponse<CachedGradeBook>.Success(cachedGradeBook);
        }
    }
}

