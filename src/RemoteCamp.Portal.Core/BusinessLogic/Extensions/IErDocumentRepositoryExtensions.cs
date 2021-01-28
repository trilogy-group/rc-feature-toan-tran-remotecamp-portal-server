using System.Collections.Generic;
using Newtonsoft.Json;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteU.Component.NoSqlClient;

namespace RemoteCamp.Portal.Core.BusinessLogic.Extensions
{
    public static class IErDocumentRepositoryExtensions
    {
        public static IList<RcTask> GetRcTask(this ErDocument erDocument)
        {
            var jiraDocument = JsonConvert.DeserializeObject<JiraDocument>(erDocument.Body);
            return jiraDocument.DocumentSubmitted;
        }
    }
}
