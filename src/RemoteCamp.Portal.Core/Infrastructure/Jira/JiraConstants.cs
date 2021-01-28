using Hangfire.Client;

namespace RemoteCamp.Portal.Core.Infrastructure.Jira
{
    public static class JiraConstants
    {
        public class StartEruValues
        {
            public static readonly string Done = "Done";
        }
        
        public class Link
        {
            public static readonly string ReviewedByLinkId = "10401";
            public static readonly string FailedWithLinkId = "10402";
        }

        public class ItOpsTicketValues
        {
            public static readonly string Created = "Created";
        }

        public static class RcReviewStatuses
        {
            public static readonly string Open = "Open";
        }

        public static class ErTicketTransitions
        {
            public static readonly string PickADateTransitionName = "Pick a date";
        }
        
        public static class ErTicketStatuses
        {
            public static readonly string Staged = "Staged";
            public static readonly string RcActive = "RC Active";
            public static readonly string RcCandidate = "RC Candidate";
            public static readonly string RcCancelled = "RC Cancelled";
            public static readonly string RcResigned = "RC Resigned";
            public static readonly string RcNonCompliance = "RC NonCompliance";
            public static readonly string RcLowPerformance = "RC Low Performance";
            public static readonly string RcGraduate = "RC Graduate";
        }
        
        public static class RcTaskStatuses
        {
            public static readonly string InReview = "In Review";
            public static readonly string InProgress = "In Progress";
            public static readonly string ToDo = "To Do";
            public static readonly string Approved = "Approved";
        }

        public static class FtarValues
        {
            public static readonly string Yes = "YES";
            public static readonly string No = "NO";
        }

        public class Field
        {
            public static readonly string Key = "key";
            public static readonly string Summary = "summary";
            public static readonly string Assignee = "assignee";
            public static readonly string Status = "status";
            public static readonly string Type = "type";
            public static readonly string Id = "id";
            public static readonly string Name = "name";
            public static readonly string Value = "value";
            public static readonly string DisplayName = "displayName";
            public static readonly string AccountId = "accountId";
            public static readonly string EmailAddress = "emailAddress";
            public static readonly string Groups = "groups";
            public static readonly string GroupName = "name";
            public static readonly string GroupItems = "items";
            public static readonly string IsActive = "active";

            public static readonly string StartDateFieldKey = "customfield_12822";
            public static readonly string StartDateFieldName = "Start Date";

            public static readonly string FtarFieldKey = "customfield_12870";
            public static readonly string FtarFieldName = "FTAR";

            public static readonly string FirstSubmissionDateFieldKey = "customfield_12859";
            public static readonly string FirstSubmissionDateFieldName = "First Submission Date";

            public static readonly string ScoreFieldKey = "customfield_12863";
            public static readonly string ScoreFieldName = "Score";

            public static readonly string CompanyEmailFieldKey = "customfield_12850";
            public static readonly string CompanyEmailFieldName = "Company Email";

            public static readonly string XoEmailEmailFieldName = "XO Login Email";

            public static readonly string ModuleFieldKey = "customfield_12861";
            public static readonly string ModuleFieldName = "Module";

            public static readonly string ReviewerFieldKey = "customfield_12862";
            public static readonly string ReviewerFieldName = "Reviewer";

            public static readonly string SubmissionUrlFieldKey = "customfield_12865";
            public static readonly string SubmissionUrlFieldName = "Submission URL";

            public static readonly string RcPipelineNameFieldKey = "customfield_12854";
            public static readonly string RcPipelineNameFieldName = "RC Pipeline Name";

            public static readonly string NameFieldName = "Name";
            public static readonly string NameFieldKey = "customfield_12847";

            public static readonly string VideoOfPurposeFieldName = "Video of Purpose";

            public static readonly string RcXoIdFieldKey = "customfield_12883";
            public static readonly string RcJiraIdFieldKey = "customfield_12884";
            public static readonly string RcXoIdFieldName = "RC xoid";
            public static readonly string RcJiraIdFieldName = "RC Jira ID";

            public static readonly string RcDeckFieldKey = "customfield_12880";
            public static readonly string RcDeckFieldName = "RC Deck";

            public static readonly string RcTMSFieldKey = "customfield_12881";
            public static readonly string RcTMSFieldName = "RC TMS";

            public static readonly string RcXoLoginEmailKey = "customfield_12849";
            public static readonly string RcXoLoginEmailName = "XO Login Email";

            public static readonly string HiringManagerFieldName = "Hiring Manager";
            public static readonly string HiringManagerFieldKey = "customfield_12815";

            public static readonly string ItOpsTicketFieldName = "ITOPS Ticket";
            public static readonly string ItOpsTicketFieldKey = "customfield_12899";

            public static readonly string AdAccountFieldName = "AD Account";
            public static readonly string AdAccountFieldKey = "customfield_12896";

            public static readonly string Application360LinkFieldKey = "customfield_12897";
            public static readonly string Application360LinkFieldName = "APPLICATION 360 LINK";

            public static readonly string GitHubIdFieldKey = "customfield_12914";
            public static readonly string GitHubIdFieldName = "Github ID";

            public static readonly string IcRemoteUFieldKey = "customfield_12902";
            public static readonly string IcRemoteUFieldName = "IC RemoteU";
            
            public static readonly string StartEruFieldKey = "customfield_12917";
            public static readonly string StartEruFieldName = "Start ERU";

            public static readonly string RemoteUModuleKey = "customfield_12961";
            public static readonly string RemoteUModuleFieldName = "RU Module";
        }

        public class Json
        {
            public static readonly string Fields = "fields";
            public static readonly string InwardIssue = "inwardIssue";
            public static readonly string OutwardIssue = "outwardIssue";
            public static readonly string IssueLinks = "issuelinks";
            public static readonly string Issues = "issues";
            public static readonly string StartAt = "startAt";
            public static readonly string MaxResults = "maxResults";
            public static readonly string Total = "total";
        }
    }
}
