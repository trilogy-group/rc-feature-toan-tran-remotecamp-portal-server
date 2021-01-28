using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public interface IProfileHardestProblemByDayService
    {
        /// <summary>
        /// Get problem resolution progress of each day for remote camp participant.
        /// </summary>
        /// <param name="email">company email address of a remote camp participant.</param>
        /// <returns></returns>
        Task<ServiceValueResponse<IList<ProfileHardestProblemByDay>>> GetAllAsync(string email);
    }
}