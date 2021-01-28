using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RemoteCamp.Portal.Core.BusinessLogic.Email.Templates;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.Common;
using RemoteCamp.Portal.Core.Infrastructure.Data;
using RemoteCamp.Portal.Core.Infrastructure.Email;
using Serilog;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public class EmailAlertService : IEmailAlertService
    {
        private readonly IWeeklyPlanService _weeklyPlanService;
        private readonly IEmailService _emailService;
        private readonly IJiraUserRepository _jiraUserRepository;
        private readonly IProfileService _profileService;
        private readonly ITimeService _timeService;
        private readonly ApplicationOptions _options;

        public EmailAlertService(
            IWeeklyPlanService weeklyPlanService,
            IEmailService emailService,
            IJiraUserRepository jiraUserRepository,
            IProfileService profileService,
            ITimeService timeService,
            ApplicationOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _weeklyPlanService = weeklyPlanService ?? throw new ArgumentNullException(nameof(weeklyPlanService));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _jiraUserRepository = jiraUserRepository ?? throw new ArgumentNullException(nameof(jiraUserRepository));
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
            _timeService = timeService ?? throw new ArgumentNullException(nameof(timeService));
        }

        public async Task SendEmailAlertForMissingWeeklyPlanSubmission()
        {
            var currentDate = _timeService.UtcNow;

            if (currentDate.DayOfWeek == DayOfWeek.Tuesday)
            {
                var result = await _weeklyPlanService.GetAllMissedWeeklyPlansAsync();

                if (result != null)
                {
                    var plans = result.Value;
                    foreach (var plan in plans)
                    {
                        try
                        {
                            var jiraUser = await _jiraUserRepository.GetByEmailAsync(plan.User.Email);
                            var profileResponse = await _profileService.GetAsync(plan.User.Email);
                            var profile = profileResponse.Value;
                            var managerJiraUser = profile.ManagerJiraUser;
                            var name = jiraUser?.DisplayName;

                            if (!profile.EruStarted)
                            {
                                Log.Logger.Information($"{name} has not started Eng. RemoteU yet");
                                continue;
                            }

                            var subject = $"Compliance - Warning - { name } - { currentDate.ToShortDateString() }";
                            var body = new MissedWeeklyPlanWarningEmailTemplate(name).TransformText();

                            await _emailService.SendEmail(
                                new SendEmailRequest
                                {
                                    Subject = subject,
                                    Body = body,
                                    FromEmail = _options.SmtpSettings.SenderEmail,
                                    SendToEmails = new List<string> { plan.User.Email },
                                    CcEmails = managerJiraUser?.EmailAddress == null 
                                        ? new List<string>(0) 
                                        : new List<string> { managerJiraUser.EmailAddress }
                                });
                        }
                        catch (Exception ex)
                        {
                            Log.Logger.Error(ex, $"Exception occurred while sending email about missing weekly plan submission {plan.User.Email}");
                        }
                    }
                }
            }
        }
    }
}
