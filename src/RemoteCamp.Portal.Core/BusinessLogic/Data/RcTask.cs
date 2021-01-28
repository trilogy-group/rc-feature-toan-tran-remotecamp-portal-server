using System;
using System.Collections.Generic;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class RcTask : BaseJiraIssue
    {
        public string Module { get; set; }

        public bool? Ftar { get; set; }

        public double? Score { get; set; }

        public string Reviewer { get; set; }

        public DateTime? FirstSubmissionDate { get; set; }

        public string SubmissionUrl { get; set; }

        public IList<RcReview> Reviews { get; set; }

        public IList<RiqbItem> FailedIqbs { get; set; }
    }
}
