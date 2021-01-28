using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.Common;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using RemoteCamp.Portal.Core.Utils;
using RemoteU.Component.NoSqlClient;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public class RcTaskLoader : IRcTaskLoader
    {
        private readonly IRcTaskJiraRepository _rcTaskRepository;
        private readonly IRcReviewJiraRepository _rcReviewRepository;
        private readonly IErDocumentRepository _erDocumentRepository;
        private readonly ITimeService _timeService;

        public RcTaskLoader(IRcTaskJiraRepository rcTaskRepository,
            IRcReviewJiraRepository rcReviewRepository,
            IErDocumentRepository erDocumentRepository,
            ITimeService timeService)
        {
            _rcTaskRepository = rcTaskRepository;
            _rcReviewRepository = rcReviewRepository;
            _erDocumentRepository = erDocumentRepository;
            _timeService = timeService;
        }

        public async Task<IList<RcTask>> LoadAsync(Profile profile)
        {
            if (profile.Status != JiraConstants.ErTicketStatuses.RcActive)
            {
                var document = await _erDocumentRepository.GetErDocumentById(profile.JiraId);
                if (document != null)
                {
                    return document.GetRcTask().Where(x => x.FirstSubmissionDate.HasValue).ToList();
                }

                return new List<RcTask>(0);
            }

            var utcNow = _timeService.UtcNow.Date;
            var rcTickets = await _rcTaskRepository.FindFailedByAssigneeAndDatesAsync(
                profile.JiraId,
                new Range<DateTime>(utcNow.AddDays(-BusinessConstants.NumberOfDaysInRemoteCamp), utcNow.AddDays(1)));

            foreach (var rcTicket in rcTickets.Where(x => !x.Reviews.IsNullOrEmpty()))
            {
                rcTicket.Reviews = await _rcReviewRepository.FindByRcTaskAsync(rcTicket.JiraKey);
            }

            return rcTickets;
        }
    }
}