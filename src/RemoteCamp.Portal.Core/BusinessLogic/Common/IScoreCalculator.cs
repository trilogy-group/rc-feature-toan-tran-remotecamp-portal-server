using System;
using System.Collections.Generic;
using RemoteCamp.Portal.Core.BusinessLogic.Data;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public interface IScoreCalculator
    {
        double Calculate(IEnumerable<RcTask> tasks, string status);
        double CalculateDailyTarget(DateTime startDate);
    }
}