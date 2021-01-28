using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using AttlassianJiraUser = Atlassian.Jira.JiraUser;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public class JiraUserRepository : IJiraUserRepository
    {
        private readonly IJiraClientAdapter _jiraClientAdapter;

        public JiraUserRepository(IJiraClientAdapter jiraClientAdapter)
        {
            _jiraClientAdapter = jiraClientAdapter;
        }

        public async Task<JiraUser> GetByEmailAsync(string email, JiraUserLoadOptions loadOptions = JiraUserLoadOptions.None)
        {
            _jiraClientAdapter.Initialize();

            var result = await _jiraClientAdapter.SearchUsersAsync(email);

            JiraUser user = result?.Select(CreateJiraUserFromUserJToken)
                .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            user.Email = email;
            if (loadOptions != JiraUserLoadOptions.None)
            {
                if (loadOptions.HasFlag(JiraUserLoadOptions.Groups))
                {
                    var fullUser = await GetFullUserAsync(user.AccountId);
                    user.Groups = fullUser.Groups;
                }
            }

            return user;
        }

        public async Task<JiraUser> GetFullUserAsync(string accountId)
        {
            _jiraClientAdapter.Initialize();

            var url = $"/rest/api/3/user/?accountId={accountId}&expand=groups";
            var response = await _jiraClientAdapter.InvokeGetRequestAsync(url);
            return CreateJiraUserFromUserJToken(response);
        }
        
        private static JiraUser CreateJiraUserFromUserJToken(JToken token)
        {
            return new JiraUser
            {
                AccountId = token.Value<string>(JiraConstants.Field.AccountId),
                Email = token.Value<string>(JiraConstants.Field.EmailAddress),
                DisplayName = token.Value<string>(JiraConstants.Field.DisplayName),
                IsActive = token.Value<bool>(JiraConstants.Field.IsActive),
                Groups = token[JiraConstants.Field.Groups]?[JiraConstants.Field.GroupItems]
                    .Select(y => y.Value<string>(JiraConstants.Field.GroupName))
                    .ToList()
            };
        }
    }
}
