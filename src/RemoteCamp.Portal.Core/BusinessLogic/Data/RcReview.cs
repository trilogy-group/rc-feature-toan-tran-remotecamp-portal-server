
using System.Collections.Generic;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class RcReview : BaseJiraIssue
    {
        public IList<RiqbItem> FailedIqbs { get; set; }
    }
}
