using System.Security.Claims;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Core.BusinessLogic.Data;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public interface IClaimIdentityService
    {
        Task<ServiceValueResponse<ClaimsIdentity>> CreateFromGoogleAccountAsync(string googleToken);

        Task<ServiceValueResponse<ClaimsIdentity>> CreateFromApiKey(ApiKey apiKey);

        Task<ServiceValueResponse<ClaimsIdentity>> CreateImpersonatedAsync(ClaimsIdentity claimsIdentity, string email);
    }
}
