using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Atlassian.Jira;
using log4net;
using Newtonsoft.Json.Linq;
using RemoteCamp.Portal.Core.Infrastructure.Data;
using RemoteCamp.Portal.Core.Infrastructure.Google;
using RemoteCamp.Portal.Core.Utils;
using RestSharp;

namespace RemoteCamp.Portal.Core.Infrastructure.Jira
{
    public class JiraClientAdapter : IJiraClientAdapter
    {
        private const int BATCH_SIZE = 100;

        private readonly ApplicationOptions _options;
        private ILog _log = LogManager.GetLogger(typeof(ReadonlyJiraIssueService));
        private Atlassian.Jira.Jira _jira;

        public JiraClientAdapter(ApplicationOptions options)
        {
            _options = options;
        }

        public IIssueService Issues
        {
            get
            {
                if (_jira == null)
                {
                    throw new InvalidOperationException("Jira is not initialized");
                }

                if (!_options.IsProductionMode)
                {
                    _log.Warn("Not Production Mode: ReadonlyJiraIssueService is used");
                    return new ReadonlyJiraIssueService(_jira.Issues);
                }
                
                return _jira.Issues;
            }
        }

        public void Initialize()
        {
            _jira = Atlassian.Jira.Jira.CreateRestClient(
                "https://crossover.atlassian.net",
                _options.XoJiraUserName,
                _options.XoJiraPassword);
        }

        public JToken InvokeGetRequest(string resource)
        {
            return AsyncUtil.RunSync(() => _jira.RestClient.ExecuteRequestAsync(Method.GET, resource));
        }

        public Task<JToken> InvokeGetRequestAsync(string resource)
        {
            return _jira.RestClient.ExecuteRequestAsync(Method.GET, resource);
        }

        public async Task<JArray> SearchUsersAsync(string query)
        {
             var response = await InvokeGetRequestAsync($"rest/api/2/user/search?query={query}");
             return response as JArray;
        }

        public async Task<List<Issue>> LoadAllIssuesAsync(
            string jql,
            string[] fields = null)
        {
            var result = new List<Issue>(BATCH_SIZE);
            IPagedQueryResult<Issue> issues;
            var startAt = 0;
            do
            {
                var issueSearchOptions = new IssueSearchOptions(jql)
                {
                    StartAt = startAt,
                    MaxIssuesPerRequest = BATCH_SIZE,
                    FetchBasicFields = fields == null,
                    AdditionalFields = fields
                };
                issues = await Issues.GetIssuesFromJqlAsync(issueSearchOptions);
                result.AddRange(issues);
                startAt = issues.StartAt + issues.ItemsPerPage;
            } while (issues.StartAt + issues.ItemsPerPage < issues.TotalItems);

            return result;
        }

        public async Task<List<T>> LoadAllIssuesAsync<T>(
            string jql,
            string[] fields,
            Func<JToken, T> createItemFromIssueCallback)
        {
            var result = new List<T>(BATCH_SIZE);
            var startAt = 0;
            int resultStartAt;
            int resultMaxResults;
            int resultTotalItems;
            _log.Info($"Load issues with JQL: {jql}");
            do
            {
                var request = string.Format(
                    "rest/api/2/search?jql={0}&startAt={1}&maxResults={2}&fields={3}",
                    HttpUtility.UrlEncode(jql),
                    startAt,
                    BATCH_SIZE,
                    string.Join(",", fields));

                var searchResponse = await InvokeGetRequestAsync(request);
                result.AddRange(searchResponse[JiraConstants.Json.Issues].Select(createItemFromIssueCallback));

                resultStartAt = searchResponse[JiraConstants.Json.StartAt].ToObject<int>();
                resultMaxResults = searchResponse[JiraConstants.Json.MaxResults].ToObject<int>();
                resultTotalItems = searchResponse[JiraConstants.Json.Total].ToObject<int>();
                startAt = resultStartAt + resultMaxResults;
            } while (resultStartAt + resultMaxResults < resultTotalItems);

            return result;
        }
    }
}