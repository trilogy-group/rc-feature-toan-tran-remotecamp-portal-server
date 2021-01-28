using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atlassian.Jira;
using Newtonsoft.Json.Linq;

namespace RemoteCamp.Portal.Core.Infrastructure.Jira
{
    public interface IJiraClientAdapter
    {
        void Initialize();
        IIssueService Issues { get; }

        JToken InvokeGetRequest(string resource);

        Task<JToken> InvokeGetRequestAsync(string resource);

        Task<JArray> SearchUsersAsync(string query);

        Task<List<Issue>> LoadAllIssuesAsync(string jql, string[] fields = null);
        Task<List<T>> LoadAllIssuesAsync<T>(string jql, string[] fields, Func<JToken, T> createItemFromIssueCallback);
    }
}
