using System.Collections.Generic;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class JiraUser
    {
        public string AccountId { get; set; }
        
        public string DisplayName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public IList<string> Groups { get; set; }
    }
}
