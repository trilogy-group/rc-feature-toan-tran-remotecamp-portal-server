using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCamp.Portal.Core.Infrastructure.Email
{
    public interface IEmailService
    {
        Task SendEmail(SendEmailRequest emailRequest);
    }
}
