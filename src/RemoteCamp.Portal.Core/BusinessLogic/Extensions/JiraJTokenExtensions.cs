using Newtonsoft.Json.Linq;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Infrastructure.Jira;

namespace RemoteCamp.Portal.Core.BusinessLogic.Extensions
{
    public static class JiraJTokenExtensions
    {
        public static JiraUserValue ToJiraUserValue(this JToken assignee)
        {
            if (assignee == null || assignee.Type == JTokenType.Null)
            {
                return null;
            }

            return new JiraUserValue
            {
                DisplayName = assignee.SelectToken(JiraConstants.Field.DisplayName)?.ToString(),
                AccountId = assignee.SelectToken(JiraConstants.Field.AccountId)?.ToString(),
                EmailAddress = assignee.SelectToken(JiraConstants.Field.EmailAddress)?.ToString(),
            };
        }
    }
}