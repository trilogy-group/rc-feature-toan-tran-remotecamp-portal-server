using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Web.Models;

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.Admin)]
    public class WeeklyPlanReviewController : ApplicationControllerBase
    {
        private readonly IWeeklyPlanService _weeklyPlanService;

        public WeeklyPlanReviewController(IWeeklyPlanService weeklyPlanService)
        {
            _weeklyPlanService = weeklyPlanService;
        }

        [HttpPut]
        public async Task<ActionResult> Put(WeeklyPlanReviewApprovalRequest approvalRequest)
        {
            var response = await _weeklyPlanService.ChangeWeelyPlanApprovalAsync(
                approvalRequest.Email, 
                approvalRequest.IsApproved, 
                approvalRequest.WeekNumber);

            return CreateResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WeeklyPlanReviewSaveRequest saveRequest)
        {
            var deadLine = DayOfWeek.Tuesday;
            var response = await _weeklyPlanService.SubmitPlansAsync(
                saveRequest.Email, 
                saveRequest.Plans, 
                deadLine);

            return CreateResponse(response);
        }
    }
}