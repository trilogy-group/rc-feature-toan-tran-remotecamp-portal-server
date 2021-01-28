using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public interface IProfileCrnFindingService
    {
        Task<ServiceValueResponse<IList<CrnFinding>>> GetAllAsync(string email);
    }
}