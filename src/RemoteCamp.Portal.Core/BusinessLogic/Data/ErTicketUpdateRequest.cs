using Atlassian.Jira;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class ErTicketUpdateRequest
    {
        public string JiraKey { get; set; }

        public bool UpdateDeckUrl { get; set; }
        public string DeckUrl { get; set; }

        public bool UpdateTmsUrl { get; set; }
        public string TmsUrl { get; set; }

        public bool UpdateContractUrl { get; set; }
        public string ContractUrl { get; set; }

        public bool UpdatePipeline { get; set; }
        public string Pipeline { get; set; }

        public bool UpdateName { get; set; }
        public string Name { get; set; }

        public bool UpdateVideoOfPurpose { get; set; }
        public string VideoOfPurpose { get; set; }

        public bool UpdateStartDate { get; set; }
        public DateTime? StartDate { get; set; }

        public bool UpdateItOpsTicket { get; set; }
        public string ItOpsTicket { get; set; }

        public string TransitionName { get; set; }

        public bool UpdateGitHubId { get; set; }
        public string GitHubId { get; set; }

        public IList<UploadAttachmentInfo> UploadAttachmentInfo { get; set; } = new List<UploadAttachmentInfo>();

        public IList<string> LabelsForAdding { get; set; } = new List<string>();
    }
}
