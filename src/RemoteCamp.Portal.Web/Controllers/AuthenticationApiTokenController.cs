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
using RemoteCamp.Portal.Core.BusinessLogic.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationApiTokenController : ApplicationControllerBase
    {
        private readonly IJwtTokenFactory _jwtTokenFactory;
        private readonly IClaimIdentityService _claimIdentityService;

        public AuthenticationApiTokenController(
            IJwtTokenFactory jwtTokenFactory,
            IClaimIdentityService claimIdentityService)
        {
            _jwtTokenFactory = jwtTokenFactory;
            _claimIdentityService = claimIdentityService;
        }

        [HttpPost]
        public async Task<ActionResult<ClaimsIdentity>> Post(ApiKey apiKey)
        {
            var identityResponse = await _claimIdentityService.CreateFromApiKey(apiKey);
            if (identityResponse.IsSuccess)
            {
                var jwtToken = _jwtTokenFactory.Create(identityResponse.Value);
                return Created(Request.Path, jwtToken);
            }

            if (identityResponse.ContainsErrorCode(ErrorCodes.InvalidApiKey))
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Invalid Api Key");
            }

            return CreateResponse(identityResponse);
        }
    }
}
