using System.Security.Claims;

namespace RemoteCamp.Portal.Web.Core.Security
{
    public interface IJwtTokenFactory
    {
        string Create(ClaimsIdentity claimsIdentity);
        /// <summary>
        /// Create a new jwt token with extend expiration date and same claims from existing token. 
        /// </summary>
        /// <param name="tokenString">The existing jwt token.</param>
        /// <returns>The new token.</returns>
        string Renew(string tokenString);
    }
}