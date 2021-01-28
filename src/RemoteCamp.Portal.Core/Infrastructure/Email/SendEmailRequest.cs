using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteCamp.Portal.Core.Infrastructure.Email
{
    public class SendEmailRequest
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FromEmail { get; set; }
        public IList<string> SendToEmails { get; set; }
        public IList<string> CcEmails { get; set; }
    }
}
