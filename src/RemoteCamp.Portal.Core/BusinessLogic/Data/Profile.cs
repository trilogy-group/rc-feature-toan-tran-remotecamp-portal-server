using Atlassian.Jira;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class Profile
    {
        public DateTime? StartDate { get; set; }
        public string JiraId { get; set; }
        public string CompanyEmail { get; set; }
        public string XoLoginEmail { get; set; }
        public string IcName { get; set; }
        public string DeckUrl { get; set; }
        public string TmsUrl { get; set; }
        public string ContractUrl { get; set; }
        public string Pipeline { get; set; }
        public int? PipelineJiraId { get; set; }
        public string Name { get; set; }
        public string AdAccount { get; set; }
        public string Status { get; set; }
        public JiraUserValue ManagerJiraUser { get; set; }
        public bool IcRemoteUEnabled { get; set; }
        public int? XoId { get; set; }
        public bool EruStarted { get; set; }
        public int? RemoteUModuleId { get; set; }
    }
}
