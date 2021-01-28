using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Infrastructure.Security;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.ActiveOrFormerStudent)]
    public class UserCalendarItemItemController : ApplicationControllerBase
    {
        private readonly IProfileUserCalendarService _profileUserCalendarService;

        public UserCalendarItemItemController(IProfileUserCalendarService profileUserCalendarService)
        {
            _profileUserCalendarService = profileUserCalendarService ?? throw new ArgumentNullException(nameof(profileUserCalendarService));
        }

        [HttpPut("{id}/{isCompleted}")]
        public async Task<ActionResult> UpdateItemStatus([FromRoute]int id, [FromRoute] bool isCompleted)
        {
            var email = User.Claims.GetEmail();
            var response = await _profileUserCalendarService.UpdateItemStatusAsync(email, id, isCompleted);
            return CreateResponse(response);
        }
    }
}