using System;
using System.Threading.Tasks;
using log4net;
using RemoteCamp.Portal.Core.BusinessLogic.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public class JobFactory : IJobFactory
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(JobFactory));
        private readonly ICacheService _cacheService;
        private readonly IGradeBookService _gradeBookService;
        private readonly IEmailAlertService _emailAlertService;

        public JobFactory(
            ICacheService cacheService, 
            IGradeBookService gradeBookService,
            IEmailAlertService emailAlertService)
        {
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            _gradeBookService = gradeBookService ?? throw new ArgumentNullException(nameof(gradeBookService));
            _emailAlertService = emailAlertService ?? throw new ArgumentNullException(nameof(emailAlertService));
        }

        public async Task ExecuteGradeBookRecurringJob()
        {
            _log.Info($"ExecuteIcGradeBookRecurringJob Started:{ DateTime.UtcNow}");

            var result = await _gradeBookService.GetAllAsync();

            _log.Info($"GradeBook Cache Updated: { DateTime.UtcNow}");
            _cacheService.Set(BusinessConstants.GradeBookEntityKey,
                result,
                CacheEntryOption.CreateMemoryCacheEntryOptions());

            _log.Info($"IcGradeBook Cache Updated: { DateTime.UtcNow}");
            _cacheService.Set(BusinessConstants.IcGradeBookEntityKey,
                result,
                CacheEntryOption.CreateMemoryCacheEntryOptions());

            _log.Info($"ExecuteIcGradeBookRecurringJob Completed:{ DateTime.UtcNow}");
        }

        public async Task ExecuteWeeklyPlanMissedEmailSendingRecurringJob()
        {
            var currentDate = DateTime.UtcNow;
            _log.Info($"ExecuteWeeklyPlanMissedEmailSendingRecurringJob Started:{ currentDate }");

            await _emailAlertService.SendEmailAlertForMissingWeeklyPlanSubmission();

            _log.Info($"ExecuteWeeklyPlanMissedEmailSendingRecurringJob Completed:{ currentDate }");
        }
    }
}
