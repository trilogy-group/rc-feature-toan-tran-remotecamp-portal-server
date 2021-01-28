using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Atlassian.Jira;
using Atlassian.Jira.Linq;
using log4net;

namespace RemoteCamp.Portal.Core.Infrastructure.Google
{
    public class ReadonlyJiraIssueService : IIssueService
    {
        private ILog _log = LogManager.GetLogger(typeof(ReadonlyJiraIssueService));
        private readonly IIssueService _issueService;

        public ReadonlyJiraIssueService(IIssueService issueService)
        {
            _issueService = issueService;
        }

        public Task<Issue> GetIssueAsync(string issueKey, CancellationToken token = new CancellationToken())
        {
            return _issueService.GetIssueAsync(issueKey, token);
        }

        public Task<IDictionary<string, Issue>> GetIssuesAsync(IEnumerable<string> issueKeys, CancellationToken token = new CancellationToken())
        {
            return _issueService.GetIssuesAsync(issueKeys, token);
        }

        public Task<IDictionary<string, Issue>> GetIssuesAsync(params string[] issueKeys)
        {
            return _issueService.GetIssuesAsync(issueKeys);
        }

        public Task UpdateIssueAsync(Issue issue, CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("UpdateIssueAsync({0})", 
                serialize(issue));

            return Task.FromResult(0);
        }

        public Task UpdateIssueAsync(Issue issue, IssueUpdateOptions options, CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("UpdateIssueAsync({0}, {1})",
                serialize(issue), 
                serialize(options));

            return Task.FromResult(0);
        }

        public Task<string> CreateIssueAsync(Issue issue, CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("CreateIssueAsync({0})",
                serialize(issue));

            return Task.FromResult(string.Empty);
        }

        public Task DeleteIssueAsync(string issueKey, CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("DeleteIssueAsync({0})", issueKey);

            return Task.FromResult(0);
        }

        public Task<IPagedQueryResult<Issue>> GetIssuesFromJqlAsync(
            string jql,
            int? maxIssues = null,
            int startAt = 0,
            CancellationToken token = new CancellationToken())
        {
            return _issueService.GetIssuesFromJqlAsync(jql, maxIssues, startAt, token);
        }

        public Task<IPagedQueryResult<Issue>> GetIssuesFromJqlAsync(IssueSearchOptions options, CancellationToken token = new CancellationToken())
        {
            return _issueService.GetIssuesFromJqlAsync(options, token);
        }

        public Task ExecuteWorkflowActionAsync(
            Issue issue,
            string actionName,
            WorkflowTransitionUpdates updates,
            CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("ExecuteWorkflowActionAsync({0}, {1}, {2})",
                serialize(issue),
                actionName,
                serialize(updates));

            return Task.FromResult(string.Empty);
        }

        public Task<IssueTimeTrackingData> GetTimeTrackingDataAsync(string issueKey, CancellationToken token = new CancellationToken())
        {
            return _issueService.GetTimeTrackingDataAsync(issueKey, token);
        }

        public Task<IDictionary<string, IssueFieldEditMetadata>> GetFieldsEditMetadataAsync(string issueKey, CancellationToken token = new CancellationToken())
        {
            return _issueService.GetFieldsEditMetadataAsync(issueKey, token);
        }

        public Task<Comment> AddCommentAsync(string issueKey, Comment comment, CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("AddCommentAsync({0}, {1})",
                issueKey,
                serialize(comment));

            return Task.FromResult(comment);
        }

        public Task<IEnumerable<Comment>> GetCommentsAsync(string issueKey, CancellationToken token = new CancellationToken())
        {
            return _issueService.GetCommentsAsync(issueKey, token);
        }

        public Task<IEnumerable<Comment>> GetCommentsAsync(string issueKey, CommentQueryOptions options, CancellationToken token = new CancellationToken())
        {
            return _issueService.GetCommentsAsync(issueKey, options, token);
        }

        public Task DeleteCommentAsync(string issueKey, string commentId, CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("DeleteCommentAsync({0}, {1})",
                issueKey,
                commentId);

            return Task.FromResult(0);
        }

        public Task<Comment> UpdateCommentAsync(string issueKey, Comment comment, CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("UpdateCommentAsync({0}, {1})",
                issueKey,
                serialize(comment));

            return Task.FromResult(comment);
        }

        public Task<IPagedQueryResult<Comment>> GetPagedCommentsAsync(
            string issueKey,
            int? maxComments = null,
            int startAt = 0,
            CancellationToken token = new CancellationToken())
        {
            return _issueService.GetPagedCommentsAsync(
                issueKey,
                maxComments,
                startAt,
                token);
        }

        public Task<IEnumerable<IssueTransition>> GetActionsAsync(string issueKey, CancellationToken token = new CancellationToken())
        {
            return _issueService.GetActionsAsync(issueKey, token);
        }

        public Task<IEnumerable<Attachment>> GetAttachmentsAsync(string issueKey, CancellationToken token = new CancellationToken())
        {
            return _issueService.GetAttachmentsAsync(issueKey, token);
        }

        public Task<string[]> GetLabelsAsync(string issueKey, CancellationToken token = new CancellationToken())
        {
            #pragma  warning disable 0618
            return _issueService.GetLabelsAsync(issueKey, token);
        }

        public Task SetLabelsAsync(string issueKey, string[] labels, CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("SetLabelsAsync({0}, {1})",
                issueKey,
                serialize(labels));

            return Task.FromResult(0);
        }

        public Task<IEnumerable<JiraUser>> GetWatchersAsync(string issueKey, CancellationToken token = new CancellationToken())
        {
            return _issueService.GetWatchersAsync(issueKey, token);
        }

        public Task DeleteWatcherAsync(string issueKey, string username, CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("DeleteWatcherAsync({0}, {1})",
                issueKey,
                username);

            return Task.FromResult(0);
        }

        public Task AddWatcherAsync(string issueKey, string username, CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("AddWatcherAsync({0}, {1})",
                issueKey,
                username);

            return Task.FromResult(0);
        }

        public Task<IEnumerable<IssueChangeLog>> GetChangeLogsAsync(string issueKey, CancellationToken token = new CancellationToken())
        {
            return _issueService.GetChangeLogsAsync(issueKey, token);
        }

        public Task<IPagedQueryResult<Issue>> GetSubTasksAsync(
            string issueKey,
            int? maxIssues = null,
            int startAt = 0,
            CancellationToken token = new CancellationToken())
        {
            return _issueService.GetSubTasksAsync(
                issueKey,
                maxIssues,
                startAt,
                token);
        }

        public Task AddAttachmentsAsync(
            string issueKey,
            UploadAttachmentInfo[] attachments,
            CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("AddAttachmentsAsync({0}, {1})",
                issueKey,
                attachments);

            return Task.FromResult(0);
        }

        public Task DeleteAttachmentAsync(string issueKey, string attachmentId, CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("DeleteAttachmentAsync({0}, {1})",
                issueKey,
                attachmentId);

            return Task.FromResult(0);
        }

        public Task<Worklog> GetWorklogAsync(string issueKey, string worklogId, CancellationToken token = new CancellationToken())
        {
            return _issueService.GetWorklogAsync(issueKey, worklogId, token);
        }

        public Task<IEnumerable<Worklog>> GetWorklogsAsync(string issueKey, CancellationToken token = new CancellationToken())
        {
            return _issueService.GetWorklogsAsync(issueKey, token);
        }

        public Task<Worklog> AddWorklogAsync(
            string issueKey,
            Worklog worklog,
            WorklogStrategy worklogStrategy = WorklogStrategy.AutoAdjustRemainingEstimate,
            string newEstimate = null,
            CancellationToken token = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task DeleteWorklogAsync(
            string issueKey,
            string worklogId,
            WorklogStrategy worklogStrategy = WorklogStrategy.AutoAdjustRemainingEstimate,
            string newEstimate = null,
            CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("DeleteWorklogAsync({0}, {1}, {2}, {3})",
                issueKey,
                worklogId,
                worklogStrategy,
                newEstimate);

            return Task.FromResult(0);
        }

        public Task AssignIssueAsync(string issueKey, string assignee, CancellationToken token = new CancellationToken())
        {
            _log.InfoFormat("AssignIssueAsync({0}, {1})",
                issueKey,
                assignee);

            return Task.FromResult(0);
        }

        public JiraQueryable<Issue> Queryable => _issueService.Queryable;

        public bool ValidateQuery
        {
            get => _issueService.ValidateQuery;
            set => _issueService.ValidateQuery = value;
        }

        public int MaxIssuesPerRequest
        {
            get => _issueService.MaxIssuesPerRequest;
            set => _issueService.MaxIssuesPerRequest = value;
        }

        private string serialize(object value)
        {
            return ObjectDumper.Dump(value, new DumpOptions {
                DumpStyle = DumpStyle.Console,
                MaxLevel = 2,
                LineBreakChar = string.Empty
            });
        }
    }
}
