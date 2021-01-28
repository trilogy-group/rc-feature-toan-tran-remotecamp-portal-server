using System.Threading.Tasks;
using Google.Apis.Auth;

namespace RemoteCamp.Portal.Core.Infrastructure.Google
{
    public interface IGoogleJsonWebSignatureAdapter
    {
        Task<GoogleJsonWebSignature.Payload> ValidateAsync(string token);
    }
}