using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Infrastructure.Security;
using RemoteCamp.Portal.Core.Utils;

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.Admin)]
    public class ProfileUserCheckInChatController : ApplicationControllerBase
    {
        private readonly IProfileUserCheckInChatService _profileUserCheckInChatService;

        public ProfileUserCheckInChatController(IProfileUserCheckInChatService profileUserCheckInChatService)
        {
            _profileUserCheckInChatService = profileUserCheckInChatService
                ?? throw new ArgumentNullException(nameof(profileUserCheckInChatService));
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<IList<List<UserCheckInChatItem>>>> Get(string email)
        {
            var response = await _profileUserCheckInChatService.GetAllByEmaildAsync(email);
            return CreateResponse(response);
        }

        [HttpGet("{email}/{day:int}")]
        public async Task<ActionResult<DailyCheckInChatItem>> Get(string email, int day)
        {
            var response = await _profileUserCheckInChatService.GetByEmailAndDayAsync(email, day);
            return CreateResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CheckInChat checkInChat)
        {
            var response = await _profileUserCheckInChatService.UpdateCheckInChatItemStatusAsync(checkInChat);
            return CreateResponse(response);
        }
    }

}