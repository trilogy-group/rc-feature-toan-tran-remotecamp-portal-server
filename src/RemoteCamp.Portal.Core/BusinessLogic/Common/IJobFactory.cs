using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public interface IJobFactory
    {
        Task ExecuteGradeBookRecurringJob();
    }
}
