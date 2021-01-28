using System.Security.Claims;

namespace RemoteCamp.Portal.Web.Core.Security
{
    public interface IJwtTokenFactory
    {
        string Create(ClaimsIdentity claimsIdentity);
    }
}