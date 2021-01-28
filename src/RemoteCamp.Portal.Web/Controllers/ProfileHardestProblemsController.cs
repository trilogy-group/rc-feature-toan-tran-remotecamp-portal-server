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
    public class ProfileHardestProblemsController : ApplicationControllerBase
    {
        private readonly IProfileHardestProblemService _hardestProblemService;

        public ProfileHardestProblemsController(IProfileHardestProblemService hardestProblemService)
        {
            _hardestProblemService = hardestProblemService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ProfileHardestProblem>>> Get()
        {
            var email = User.Claims.GetEmail();
            var response = await _hardestProblemService.GetAllAsync(email);
            return CreateResponse(response);
        }

        [HttpGet("{email}")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<ActionResult<IList<ProfileHardestProblem>>> Get(string email)
        {
            var response = await _hardestProblemService.GetAllAsync(email);
            return CreateResponse(response);
        }
    }
}
