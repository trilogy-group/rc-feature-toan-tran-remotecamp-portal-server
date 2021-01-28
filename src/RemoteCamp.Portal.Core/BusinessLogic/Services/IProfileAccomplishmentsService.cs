using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public interface IProfileAccomplishmentsService
    {
        Task<ServiceValueResponse<ProfileAccomplishments>> GetAsync(string email);
    }
}