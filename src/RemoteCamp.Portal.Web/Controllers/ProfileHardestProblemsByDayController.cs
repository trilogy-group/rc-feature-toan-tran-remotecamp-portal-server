using System;
using System.Collections;
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
    public class ProfileHardestProblemsByDayController : ApplicationControllerBase
    {
        private readonly IProfileHardestProblemByDayService _hardestProblemByDayService;

        public ProfileHardestProblemsByDayController(IProfileHardestProblemByDayService hardestProblemByDayService)
        {
            _hardestProblemByDayService = hardestProblemByDayService ?? throw new ArgumentNullException(nameof(hardestProblemByDayService));
        }

        [HttpGet]
        public async Task<ActionResult<IList<ProfileHardestProblemByDay>>> Get()
        {
            var email = User.Claims.GetEmail();
            var response = await _hardestProblemByDayService.GetAllAsync(email);
            return CreateResponse(response);
        }

        [HttpGet("{email}")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<ActionResult<IList<ProfileHardestProblemByDay>>> Get(string email)
        {
            var response = await _hardestProblemByDayService.GetAllAsync(email);
            return CreateResponse(response);
        }
    }
}