using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using RemoteCamp.Portal.Core.Infrastructure.Data;

namespace RemoteCamp.Portal.Core.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        private readonly ApplicationOptions _applicationOptions;

        public EmailService(ApplicationOptions applicationOptions)
        {
            _applicationOptions = applicationOptions ?? throw new ArgumentNullException(nameof(applicationOptions));
        }

        public async Task SendEmail(SendEmailRequest emailRequest)
        {
            if(emailRequest == null)
            {
                throw new ArgumentNullException("Email request is invalid");
            }

            var recipients = emailRequest.SendToEmails?.Where(x => !string.IsNullOrWhiteSpace(x));

            if (recipients?.Any() == true)
            {
                var message = new MimeMessage();
                message.Subject = emailRequest.Subject;
                message.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = emailRequest.Body };
                message.From.Add(new MailboxAddress(emailRequest.FromEmail));

                foreach (var recepient in recipients)
                {
                    message.To.Add(new MailboxAddress(recepient));
                }

                if (emailRequest.CcEmails.Any())
                {
                    foreach (var ccEmail in emailRequest.CcEmails)
                    {
                        message.Cc.Add(new MailboxAddress(ccEmail));
                    }
                }

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    await client.ConnectAsync(
                        _applicationOptions.SmtpSettings.Host,
                        _applicationOptions.SmtpSettings.Port,
                        _applicationOptions.SmtpSettings.UseSSL);

                    await client.AuthenticateAsync(
                        _applicationOptions.SmtpUserName,
                        _applicationOptions.SmtpPassword);

                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
        }
    }
}
