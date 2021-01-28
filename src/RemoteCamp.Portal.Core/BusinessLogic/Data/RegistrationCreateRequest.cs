using System;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class RegistrationCreateRequest
    {
        public string Email { get; set; }

        public int Role { get; set; }

        public DateTime StartDate { get; set; }

        public string VideoUrl { get; set; }

        public string GitHubId { get; set; }

        public byte[] SignedContract { get; set; }
    }
}
