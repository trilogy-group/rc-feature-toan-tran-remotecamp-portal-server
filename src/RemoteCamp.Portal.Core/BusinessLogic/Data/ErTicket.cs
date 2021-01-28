using System;
using System.Collections.Generic;
using Atlassian.Jira;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class ErTicket : BaseJiraIssue
    {
        public DateTime? StartDate { get; set; }

        public string HiringManager { get; set; }

        public string Name { get; set; }

        public string Pipeline { get; set; }

        public int? PipelineJiraId { get; set; }

        public int? RcXoId { get; set; }

        public string RcJiraId { get; set; }

        public string CompanyEmail { get; set; }

        public string XoLoginEmail { get; set; }

        public string DeckUrl { get; set; }

        public string TmsUrl { get; set; }

        public string ItOpsTicket { get; set; }

        public string AdAccount { get; set; }

        public string Application360Link { get; set; }

        public string GitHubId { get; set; }

        public IList<Attachment> Attachment { get; set; } = new List<Attachment>();
        
        public string IcRemoteU { get; set; }
        
        public string StartEru { get; set; }

        public int? RemoteUModuleId { get; set; }
    }
}
