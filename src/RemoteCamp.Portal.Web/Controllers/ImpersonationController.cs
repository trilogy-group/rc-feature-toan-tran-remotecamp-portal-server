using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using RemoteCamp.Portal.Core.Infrastructure.Security;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Web.Core.Security;

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.Admin)]
    public class ImpersonationController : ApplicationControllerBase
    {
        private readonly IClaimIdentityService _claimIdentityService;
        private readonly IJwtTokenFactory _jwtTokenFactory;
        private readonly IUserService _userService;

        public ImpersonationController(IClaimIdentityService claimIdentityService,
            IJwtTokenFactory jwtTokenFactory,
            IUserService userService)
        {
            _claimIdentityService = claimIdentityService;
            _jwtTokenFactory = jwtTokenFactory;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<ClaimsIdentity>> Post([FromBody] string email)
        {
            var claimsIdentityResponse = await _claimIdentityService.CreateImpersonatedAsync(User.Identities.First(), email);
            if (claimsIdentityResponse.IsSuccess)
            {
                var jwtToken = _jwtTokenFactory.Create(claimsIdentityResponse.Value);
                return Created(Request.Path, jwtToken);
            }

            if (claimsIdentityResponse.ContainsErrorCode(ErrorCodes.UserRoleWasNotDetermined)
                || claimsIdentityResponse.ContainsErrorCode(ErrorCodes.UserWasNotFound))
            {
                return NotFound("User account doesn't exists or it is not part of the RemoteU");
            }

            return CreateResponse(claimsIdentityResponse);
        }
    }
}
