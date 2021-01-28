using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Email.Templates;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Test.Common;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Email;
using RemoteCamp.Portal.Core.Infrastructure.Common;
using RemoteCamp.Portal.Core.Infrastructure.Data;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Services
{
    public class EmailAlertServiceTest : UnitTestBase
    {
        private readonly EmailAlertService _emailAlertService;

        public EmailAlertServiceTest()
        {
            _emailAlertService = ServiceProvider.GetService<EmailAlertService>();
        }

        [Fact]
        public async Task SendEmailAlertForMissingWeeklyPlanSubmission_MissedPlanExists_SendsWarningEmail()
        {
            // Arrange
            const string email = "xyq@gmail.com";
            const string displayName = "Mr. x";
            const string managerEmail = "manager@gmail.com";
            const string managerUserName = "i.manager";
            const string senderEmail = "hello@aurea.com";

            var currentDate = new DateTime(2019, 9, 24);
            var emailSubject = $"Compliance - Warning - { displayName } - { currentDate.ToShortDateString() }";
            var emailBody = new MissedWeeklyPlanWarningEmailTemplate(displayName).TransformText();
            var toAdresses = new List<string> { email };
            var ccAdresses = new List<string> { managerEmail };
            var jiraUser = new JiraUser { DisplayName = displayName };
            var missedWeek = new List<WeeklyPlanWeek>
            {
                new WeeklyPlanWeek
                {
                    WeekNumber = StudyWeek.One,
                    Submitted = false,
                    User = new User
                    {
                        Email = email
                    }
                }
            };

            var profile = new Profile
            {
                ManagerJiraUser = new JiraUserValue
                {
                    AccountId = managerUserName,
                    EmailAddress = managerEmail
                },
                EruStarted = true
            };

            var missedPlans = ServiceValueResponse<IList<WeeklyPlanWeek>>.Success(missedWeek);
            var managerProfile = ServiceValueResponse<Profile>.Success(profile);

            SetApplicationOptionsValue(senderEmail);

            ServiceProvider.GetMock<IWeeklyPlanService>()
                .Setup(x => x.GetAllMissedWeeklyPlansAsync()).ReturnsAsync(missedPlans);

            ServiceProvider.GetMock<IEmailService>()
                .Setup(x => x.SendEmail(It.Is<SendEmailRequest>(s =>
                    s.Body == emailBody &&
                    s.Subject == emailSubject &&
                    s.FromEmail == senderEmail &&
                    s.SendToEmails[0] == toAdresses[0] &&
                    s.CcEmails[0] == ccAdresses[0])))
                .Verifiable();

            ServiceProvider.GetMock<IJiraUserRepository>()
                .Setup(x => x.GetByEmailAsync(email, JiraUserLoadOptions.None)).ReturnsAsync(jiraUser);

            ServiceProvider.GetMock<IProfileService>()
                .Setup(x => x.GetAsync(email)).ReturnsAsync(managerProfile);

            ServiceProvider.GetMock<ITimeService>()
                .Setup(x => x.UtcNow).Returns(currentDate);

            // Act
            await _emailAlertService.SendEmailAlertForMissingWeeklyPlanSubmission();

            // Assert
            ServiceProvider.GetMock<IEmailService>().VerifyAll();
        }

        private void SetApplicationOptionsValue(string senderEmail)
        {
            var applicationOption = new ApplicationOptions();
            applicationOption.SmtpSettings.SenderEmail = senderEmail;
            var field = typeof(EmailAlertService).GetField("_options", BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(_emailAlertService, applicationOption);
        }
    }
}
