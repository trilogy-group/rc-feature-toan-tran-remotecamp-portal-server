using System.Collections.Generic;
using RemoteCamp.Portal.Core.BusinessLogic.Data;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public interface IHardestProblemService
    {
        IList<ProfileHardestProblemByDay> GetHardestProblemsByDay(IList<RcTask> rcTasks, Profile profile);
    }
}