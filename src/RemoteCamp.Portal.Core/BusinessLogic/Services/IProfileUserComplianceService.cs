using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public interface IProfileUserComplianceService
    {
        Task<ServiceValueResponse<ProfileCompliance>> GetComplianceByEmailAsync(string email);
    }
}
