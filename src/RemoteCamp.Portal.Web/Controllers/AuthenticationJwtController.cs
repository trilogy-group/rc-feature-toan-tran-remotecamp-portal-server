using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemoteCamp.Portal.Web.Core.Security;

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationJwtController : ApplicationControllerBase
    {
        private const string AuthorizationHeader = "Authorization";
        private const string AuthorizationHeaderTokenPrefix = "Bearer ";

        private readonly IJwtTokenFactory _jwtTokenFactory;

        public AuthenticationJwtController(
            IJwtTokenFactory jwtTokenFactory)
        {
            _jwtTokenFactory = jwtTokenFactory;
        }

        [HttpPost]

        public ActionResult<ClaimsIdentity> Post([FromHeader(Name = AuthorizationHeader)] string authorizationHeader)
        {
            if (authorizationHeader == null || !authorizationHeader.StartsWith(AuthorizationHeaderTokenPrefix))
            {
                return BadRequest("Not using token authentication");
            }

            var token = authorizationHeader.Substring(AuthorizationHeaderTokenPrefix.Length);
            return Created(Request.Path, _jwtTokenFactory.Renew(token));
        }
    }
}
