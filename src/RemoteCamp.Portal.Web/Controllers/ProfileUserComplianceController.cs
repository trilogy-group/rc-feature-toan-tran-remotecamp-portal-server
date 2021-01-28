using System;
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
    [Authorize(Policy = Policies.Admin)]
    public class ProfileUserComplianceController : ApplicationControllerBase
    {
        private readonly IProfileUserComplianceService _profileUserComplianceService;

        public ProfileUserComplianceController(IProfileUserComplianceService profileUserComplianceService)
        {
            _profileUserComplianceService = profileUserComplianceService ?? throw new ArgumentNullException(nameof(profileUserComplianceService));
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<ProfileCompliance>> Get(string email)
        {
            var response = await _profileUserComplianceService.GetComplianceByEmailAsync(email);
            return CreateResponse(response);
        }
    }
}