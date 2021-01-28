using RemoteCamp.Portal.Core.BusinessLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public interface IProfileUserComplianceRepository
    {
        Task<List<CrossoverTrackerActivity>> GetTeamComplianceByDayAsync(DateTime day, int teamId);
    }
}
