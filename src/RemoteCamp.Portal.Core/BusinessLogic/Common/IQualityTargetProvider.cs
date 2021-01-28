using RemoteCamp.Portal.Core.BusinessLogic.Data;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public interface IQualityTargetProvider
    {
        double? GetGraduationTarget(Profile profile);
        double? GetActualTarget();
    }
}