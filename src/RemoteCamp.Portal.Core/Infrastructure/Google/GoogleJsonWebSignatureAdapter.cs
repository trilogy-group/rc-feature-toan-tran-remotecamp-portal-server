using System.Threading.Tasks;
using Google.Apis.Auth;

namespace RemoteCamp.Portal.Core.Infrastructure.Google
{
    class GoogleJsonWebSignatureAdapter : IGoogleJsonWebSignatureAdapter
    {
        public Task<GoogleJsonWebSignature.Payload> ValidateAsync(string token)
        {
            return GoogleJsonWebSignature.ValidateAsync(token);
        }
    }
}
