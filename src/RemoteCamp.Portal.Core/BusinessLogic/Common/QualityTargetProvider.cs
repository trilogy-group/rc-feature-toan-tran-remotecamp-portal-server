using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.Infrastructure.Common;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public class QualityTargetProvider : IQualityTargetProvider
    {
        private readonly ITimeService _timeService;

        public QualityTargetProvider(ITimeService timeService)
        {
            _timeService = timeService;
        }
        
        public double? GetGraduationTarget(Profile profile)
        {
            return profile.GetWeekIndex(_timeService.UtcNow) >= 2 ? BusinessConstants.QualityTargetForToday : (double?)null;
        }

        public double? GetActualTarget()
        {
            return BusinessConstants.QualityTargetForToday;
        }
    }
}