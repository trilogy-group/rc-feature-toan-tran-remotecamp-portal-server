using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Infrastructure.Security;

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.ActiveOrFormerStudent)]
    public class ProfileCrnFindingsController : ApplicationControllerBase
    {
        private readonly IProfileCrnFindingService _profileCrnFindingService;

        public ProfileCrnFindingsController(IProfileCrnFindingService profileCrnFindingService)
        {
            _profileCrnFindingService = profileCrnFindingService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<CrnFinding>>> Get()
        {
            var email = User.Claims.GetEmail();
            var response = await _profileCrnFindingService.GetAllAsync(email);
            return CreateResponse(response);
        }

        [HttpGet("{email}")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<ActionResult<IList<CrnFinding>>> Get(string email)
        {
            var response = await _profileCrnFindingService.GetAllAsync(email);
            return CreateResponse(response);
        }
    }
}
