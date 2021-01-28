using Atlassian.Jira;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class ProfileUpdateRequest
    {
        public string CompanyEmail { get; set; }
        public string DeckUrl { get; set; }
        public string TmsUrl { get; set; }
        public string ContractUrl { get; set; }
        public IList<UploadAttachmentInfo> UploadAttachmentInfo { get; set; } = new List<UploadAttachmentInfo>();
    }
}
