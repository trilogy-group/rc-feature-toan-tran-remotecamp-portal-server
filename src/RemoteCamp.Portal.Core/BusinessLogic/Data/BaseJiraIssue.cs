namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class BaseJiraIssue
    {
        public string JiraKey { get; set; }

        public string Summary { get; set; }

        public JiraUserValue Assignee { get; set; }


        public string Status { get; set; }
    }
}
