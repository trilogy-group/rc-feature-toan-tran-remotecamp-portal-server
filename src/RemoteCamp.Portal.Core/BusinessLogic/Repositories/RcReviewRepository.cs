using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.Infrastructure.Jira;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public class RcReviewJiraRepository : IRcReviewJiraRepository
    {
        private static readonly string[] JiraFields =
        {
            JiraConstants.Field.Key,
            JiraConstants.Field.Summary,
            JiraConstants.Field.Assignee,
            JiraConstants.Field.Status,
            JiraConstants.Json.IssueLinks
        };

        private readonly IJiraClientAdapter _jiraClientAdapter;

        public RcReviewJiraRepository(IJiraClientAdapter jiraClientAdapter)
        {
            _jiraClientAdapter = jiraClientAdapter;
        }

        public async Task<List<RcReview>> FindByRcTaskAsync(string rcTaskJiraKey)
        {
            _jiraClientAdapter.Initialize();

            var jql = $"issue in linkedIssues('{rcTaskJiraKey}')";
            var issues = await _jiraClientAdapter.LoadAllIssuesAsync(jql, JiraFields, CreateRcReviewFromIssueJTokenCallback());

            return issues.ToList();
        }

        private static Func<JToken, RcReview> CreateRcReviewFromIssueJTokenCallback()
        {
            return x => new RcReview
            {
                JiraKey = x[JiraConstants.Field.Key].ToString(),
                Summary = x[JiraConstants.Json.Fields][JiraConstants.Field.Summary].ToString(),
                Assignee = x[JiraConstants.Json.Fields][JiraConstants.Field.Assignee].ToJiraUserValue(),
                Status = x[JiraConstants.Json.Fields][JiraConstants.Field.Status][JiraConstants.Field.Name].ToString(),
                FailedIqbs = x[JiraConstants.Json.Fields][JiraConstants.Json.IssueLinks]
                    .Where(y => y[JiraConstants.Field.Type][JiraConstants.Field.Id].Value<string>() == JiraConstants.Link.FailedWithLinkId && y[JiraConstants.Json.OutwardIssue] != null)
                    .Select(y => y[JiraConstants.Json.OutwardIssue])
                    .Select(
                        y => new RiqbItem
                        {
                            JiraKey = y[JiraConstants.Field.Key].ToString(),
                            Summary = y[JiraConstants.Json.Fields][JiraConstants.Field.Summary].ToString(),
                            Status = y[JiraConstants.Json.Fields][JiraConstants.Field.Status][JiraConstants.Field.Name].ToString(),
                        })
                    .ToList()
            };
        }
    }
}
