using System;
using System.Collections.Generic;
using RemoteCamp.Portal.Core.BusinessLogic.Data;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public interface IFtarCalculator
    {
        double? CalculateActualValue(IEnumerable<RcTask> tasks, DateTime startDate, bool includeInReview);
        
        double? CalculateGraduationValue(IEnumerable<RcTask> tasks, DateTime startDate, bool includeInReview);
    }
}