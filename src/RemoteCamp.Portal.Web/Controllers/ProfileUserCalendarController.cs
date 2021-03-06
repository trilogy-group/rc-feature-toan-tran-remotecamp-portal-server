﻿using System;
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
    public class ProfileUserCalendarController : ApplicationControllerBase
    {
        private readonly IProfileUserCalendarService _profileUserCalendarService;

        public ProfileUserCalendarController(IProfileUserCalendarService profileUserCalendarService)
        {
            _profileUserCalendarService = profileUserCalendarService ?? throw new ArgumentNullException(nameof(profileUserCalendarService));
        }

        [HttpGet]
        public async Task<ActionResult<IList<ProfileUserCalendar>>> Get()
        {
            var email = User.Claims.GetEmail();
            var response = await _profileUserCalendarService.GetAllAsync(email);
            return CreateResponse(response);
        }
    }
}