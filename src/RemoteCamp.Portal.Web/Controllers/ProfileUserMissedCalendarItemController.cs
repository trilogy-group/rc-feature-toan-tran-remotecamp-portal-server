using System;
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
    [Authorize(Policy = Policies.Admin)]
    public class ProfileUserMissedCalendarItemController : ApplicationControllerBase
    {
        private readonly IProfileUserCalendarService _profileUserCalendarService;

        public ProfileUserMissedCalendarItemController(IProfileUserCalendarService profileUserCalendarService)
        {
            _profileUserCalendarService = profileUserCalendarService ?? throw new ArgumentNullException(nameof(profileUserCalendarService));
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<IList<MissedCalendarItem>>> Get(string email)
        {
            var response = await _profileUserCalendarService.GetAllMissedCalendarItemByEmailAsync(email);
            return CreateResponse(response);
        }
    }
}