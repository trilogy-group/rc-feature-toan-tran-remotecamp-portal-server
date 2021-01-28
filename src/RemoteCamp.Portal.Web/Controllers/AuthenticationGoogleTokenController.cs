using System;
using System.Net;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Infrastructure.Security;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Web.Core.Security;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationGoogleTokenController : ApplicationControllerBase    
    {
        private readonly IJwtTokenFactory _jwtTokenFactory;
        private readonly IClaimIdentityService _claimIdentityService;

        public AuthenticationGoogleTokenController(
            IJwtTokenFactory jwtTokenFactory,
            IClaimIdentityService claimIdentityService)
        {
            _jwtTokenFactory = jwtTokenFactory;
            _claimIdentityService = claimIdentityService;
        }

        [HttpPost]
        public async Task<ActionResult<ClaimsIdentity>> Post([FromBody]string token)
        {
            var identityResponse = await _claimIdentityService.CreateFromGoogleAccountAsync(token);
            if (identityResponse.IsSuccess)
            {
                var jwtToken = _jwtTokenFactory.Create(identityResponse.Value);
                return Created(Request.Path, jwtToken);
            }

            if (identityResponse.ContainsErrorCode(ErrorCodes.InvalidGoogleToken))
            {
                return NotFound("Google Account was not found");
            }

            if (identityResponse.ContainsErrorCode(ErrorCodes.UserRoleWasNotDetermined) 
                || identityResponse.ContainsErrorCode(ErrorCodes.UserWasNotFound))
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "User account is not part of the RemoteU");
            }

            return CreateResponse(identityResponse);
        }
    }
}
