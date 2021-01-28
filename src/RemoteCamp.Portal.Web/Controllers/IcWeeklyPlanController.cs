using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Security;

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IcWeeklyPlanController : ApplicationControllerBase
    {
        private readonly IWeeklyPlanService _weeklyPlanService;

        public IcWeeklyPlanController(IWeeklyPlanService weeklyPlanService)
        {
            _weeklyPlanService = weeklyPlanService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<WeeklyPlanWeek>>> Get()
        {
            var email = User.Claims.GetEmail();
            var response = await _weeklyPlanService.GetAllAsync(email);
            return CreateResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult<IList<WeeklyPlanWeek>>> Post(IList<WeeklyPlanWeek> plans)
        {
            var deadLine = DayOfWeek.Monday;
            var email = User.Claims.GetEmail();
            var response = await _weeklyPlanService.SubmitPlansAsync(email, plans, deadLine);
            return CreateResponse(response);
        }

        [HttpGet("{email}/{day:int}")]
        public async Task<ActionResult<WeeklyPlanDay>> Get([FromRoute] string email, [FromRoute] int day)
        {
            var response = await _weeklyPlanService.GetIcPlanDay(email, day);
            return CreateResponse(response);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<IList<WeeklyPlanWeek>>> Get([FromRoute] string email)
        {
            var response = await _weeklyPlanService.GetAllAsync(email);
            return CreateResponse(response);
        }
    }
}