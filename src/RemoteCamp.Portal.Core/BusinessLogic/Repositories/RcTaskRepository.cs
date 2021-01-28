using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Atlassian.Jira;
using Newtonsoft.Json.Linq;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.Infrastructure.Data;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using RemoteCamp.Portal.Core.Utils;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public class RcTaskJiraRepository : IRcTaskJiraRepository
    {
        private static readonly string[] JiraFields =
        {
            JiraConstants.Field.Key,
            JiraConstants.Field.Summary,
            JiraConstants.Field.Assignee,
            JiraConstants.Field.Status,
            JiraConstants.Field.FirstSubmissionDateFieldKey,
            JiraConstants.Field.FtarFieldKey,
            JiraConstants.Field.ScoreFieldKey,
            JiraConstants.Field.ModuleFieldKey,
            JiraConstants.Field.ReviewerFieldKey,
            JiraConstants.Field.SubmissionUrlFieldKey,
            JiraConstants.Json.IssueLinks
        };

        private static readonly Dictionary<RcTaskLoadOptions, string> FieldMapping = new Dictionary<RcTaskLoadOptions, string> {
        { RcTaskLoadOptions.Key, JiraConstants.Field.Key },
        { RcTaskLoadOptions.Summary, JiraConstants.Field.Summary },
        { RcTaskLoadOptions.Assignee, JiraConstants.Field.Assignee },
        { RcTaskLoadOptions.Status, JiraConstants.Field.Status },
        { RcTaskLoadOptions.FirstSubmissionDate, JiraConstants.Field.FirstSubmissionDateFieldKey },
        { RcTaskLoadOptions.Ftar, JiraConstants.Field.FtarFieldKey },
        { RcTaskLoadOptions.Score, JiraConstants.Field.ScoreFieldKey },
        { RcTaskLoadOptions.Module, JiraConstants.Field.ModuleFieldKey },
        { RcTaskLoadOptions.Reviewer, JiraConstants.Field.ReviewerFieldKey },
        { RcTaskLoadOptions.SubmissionUrl, JiraConstants.Field.SubmissionUrlFieldKey },
        { RcTaskLoadOptions.IssueLinks, JiraConstants.Json.IssueLinks }
    };

        private readonly IJiraClientAdapter _jiraClientAdapter;
        private readonly ApplicationOptions _applicationOptions;

        public RcTaskJiraRepository(IJiraClientAdapter jiraClientAdapter, ApplicationOptions applicationOptions)
        {
            _jiraClientAdapter = jiraClientAdapter;
            _applicationOptions = applicationOptions;
        }

        public async Task<List<RcTask>> FindByAssigneeAsync(string assignee, RcTaskLoadOptions rcTaskLoadOptions = RcTaskLoadOptions.All)
        {
            _jiraClientAdapter.Initialize();

            var jql = $"project='{_applicationOptions.JiraSettings.AssignmentsProject}' AND assignee = '{assignee}' and (STATUS in ('In Progress', 'In Review', 'Approved') or 'First Submission Date' is not empty)";
            
            var fields = GetJiraFields(rcTaskLoadOptions).ToArray();
            var issues = await _jiraClientAdapter.LoadAllIssuesAsync(jql, fields, CreateRcTaskFromIssueJTokenCallback());
            return issues.ToList();
        }

        public async Task<List<RcTask>> FindFailedByAssigneeAndDatesAsync(string assignee, Range<DateTime> dateRange,
            RcTaskLoadOptions rcTaskLoadOptions = RcTaskLoadOptions.All)
        {
            _jiraClientAdapter.Initialize();
            var jql = $"project = '{_applicationOptions.JiraSettings.AssignmentsProject}' AND assignee = '{assignee}' AND 'First Submission Date' >='{dateRange.From.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture)}' and 'First Submission Date'<='{dateRange.To.ToString("yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture)}' AND status !='To Do' and FTAR in ('NO')";

            var issues = await _jiraClientAdapter.LoadAllIssuesAsync(jql, JiraFields, CreateRcTaskFromIssueJTokenCallback());

            return issues.ToList();
        }

        public async Task<IList<RcTask>> FindAllAsync(RcTaskLoadOptions rcTaskLoadOptions)
        {
            _jiraClientAdapter.Initialize();
            var jql = $"project = '{_applicationOptions.JiraSettings.AssignmentsProject}' AND assignee is not EMPTY AND 'First Submission Date' is not empty and 'First Submission Date'>startOfWeek(-28d)";

            var fields = GetJiraFields(rcTaskLoadOptions);

            var issues = await _jiraClientAdapter.LoadAllIssuesAsync(jql,
                fields.ToArray(),
                CreateRcTaskFromIssueJTokenCallback());
            return issues.ToList();
        }

        private static Func<JToken, RcTask> CreateRcTaskFromIssueJTokenCallback()
        {
            return x => new RcTask
            {
                JiraKey = x[JiraConstants.Field.Key]?.ToString(),
                Summary = x[JiraConstants.Json.Fields][JiraConstants.Field.Summary]?.ToString(),
                Assignee = x[JiraConstants.Json.Fields][JiraConstants.Field.Assignee].ToJiraUserValue(),
                Module = x[JiraConstants.Json.Fields][JiraConstants.Field.ModuleFieldKey]?.SelectToken(JiraConstants.Field.Value)?.ToString(),
                Ftar = GetFtarFromJToken(x),
                Reviewer = x[JiraConstants.Json.Fields][JiraConstants.Field.ReviewerFieldKey]?.SelectToken(JiraConstants.Field.Key)?.ToString(),
                Status = x[JiraConstants.Json.Fields][JiraConstants.Field.Status][JiraConstants.Field.Name]?.ToString(),
                Score = double.TryParse(x[JiraConstants.Json.Fields][JiraConstants.Field.ScoreFieldKey]?.ToString(), out var score) ? score : (double?)null,
                FirstSubmissionDate = DateTime.TryParse(x[JiraConstants.Json.Fields][JiraConstants.Field.FirstSubmissionDateFieldKey]?.ToString(), out var firstSuDateTime) ? firstSuDateTime : (DateTime?)null,
                SubmissionUrl = x[JiraConstants.Json.Fields][JiraConstants.Field.SubmissionUrlFieldKey]?.Value<string>(),
                Reviews = x[JiraConstants.Json.Fields][JiraConstants.Json.IssueLinks] != null ? x[JiraConstants.Json.Fields][JiraConstants.Json.IssueLinks]
                    .Where(y => y[JiraConstants.Field.Type][JiraConstants.Field.Id].Value<string>() == JiraConstants.Link.ReviewedByLinkId && y[JiraConstants.Json.InwardIssue] != null)
                    .Select(y => y[JiraConstants.Json.InwardIssue])
                    .Select(
                        y => new RcReview
                        {
                            JiraKey = y[JiraConstants.Field.Key].ToString(),
                            Summary = y[JiraConstants.Json.Fields][JiraConstants.Field.Summary].ToString(),
                            Status = y[JiraConstants.Json.Fields][JiraConstants.Field.Status][JiraConstants.Field.Name].ToString(),
                        })
                    .ToList() : new List<RcReview>(),
                FailedIqbs = x[JiraConstants.Json.Fields][JiraConstants.Json.IssueLinks] != null ? x[JiraConstants.Json.Fields][JiraConstants.Json.IssueLinks]
                    .Where(y => y[JiraConstants.Field.Type][JiraConstants.Field.Id].Value<string>() == JiraConstants.Link.FailedWithLinkId && y[JiraConstants.Json.OutwardIssue] != null)
                    .Select(y => y[JiraConstants.Json.OutwardIssue])
                    .Select(
                        y => new RiqbItem
                        {
                            JiraKey = y[JiraConstants.Field.Key].ToString(),
                            Summary = y[JiraConstants.Json.Fields][JiraConstants.Field.Summary].ToString(),
                            Status = y[JiraConstants.Json.Fields][JiraConstants.Field.Status][JiraConstants.Field.Name].ToString(),
                        })
                    .ToList() : new List<RiqbItem>()
            };
        }

        private bool? GetFtarOrNull(CustomFieldValue customFieldValue)
        {
            return customFieldValue?.Values[0].Equals(JiraConstants.FtarValues.Yes, StringComparison.OrdinalIgnoreCase);
        }

        private double? GetDoubleOrNull(CustomFieldValue customFieldValue)
        {
            return double.TryParse(customFieldValue?.Values[0], out var result) ? result : (double?)null;
        }

        private DateTime? GetDateTimeOrNull(CustomFieldValue customFieldValue)
        {
            return DateTime.TryParse(customFieldValue?.Values[0], out var result) ? result : (DateTime?)null;
        }

        private static bool? GetFtarFromJToken(JToken x)
        {
            var ftar = x[JiraConstants.Json.Fields][JiraConstants.Field.FtarFieldKey].SelectToken(JiraConstants.Field.Value)?.ToString();
            if (ftar != null && ftar.Equals(JiraConstants.FtarValues.Yes, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (ftar != null && ftar.Equals(JiraConstants.FtarValues.No, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                return null;
            }
        }

        private static IEnumerable<string> GetJiraFields(RcTaskLoadOptions loadOptions)
        {
            return FieldMapping
                .Where(x => loadOptions.HasFlag(x.Key))
                .Select(x => x.Value);
        }
    }
}
