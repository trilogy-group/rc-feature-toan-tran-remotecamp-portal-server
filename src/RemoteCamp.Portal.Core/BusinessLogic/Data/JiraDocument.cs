using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class JiraDocument
    {
        [JsonProperty(PropertyName = "DocumnetSubmitted")]
        public IList<RcTask> DocumentSubmitted { get; set; } = new List<RcTask>();
    }
}
