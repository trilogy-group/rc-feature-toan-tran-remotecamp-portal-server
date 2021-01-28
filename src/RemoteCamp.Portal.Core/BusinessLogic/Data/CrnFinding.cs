using System;
using System.Collections.Generic;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class CrnFinding
    {
        public string Summary { get; set; }
        public string Link { get; set; }
        public IList<FailedInIssue> FailedIn { get; set; } = new List<FailedInIssue>();
        public class FailedInIssue
        {
            public string JiraKey { get; set; }
            public string Summary { get; set; }
        }
    }
}
