using System.Collections.Generic;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class ProfileHardestProblem
    {
        public string JiraKey { get; set; }
        public string Summary { get; set; }
        public string FailedInJiraLink { get; set; }
        public double StackRank { get; set; }
        public bool Resolved { get; set; }
        public IList<FailedInIssue> FailedIn { get; set; } = new List<FailedInIssue>();

        public class FailedInIssue
        {
            public string JiraKey { get; set; }
            public string Summary { get; set; }
        }
    }
}
