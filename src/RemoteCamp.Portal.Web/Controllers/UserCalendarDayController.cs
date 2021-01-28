using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Services;

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Policies.Admin)]
    public class UserCalendarDayController : ApplicationControllerBase
    {
        private readonly IUserCalendarDayService _userCalendarDayService;

        public UserCalendarDayController(IUserCalendarDayService userCalendarDayService)
        {
            _userCalendarDayService = userCalendarDayService ?? throw new ArgumentNullException(nameof(userCalendarDayService));
        }

        [HttpGet("{email}/{dateTime}")]
        public async Task<ActionResult<UserCalendarDay>> Get(string email, DateTime dateTime)
        {
            var response = await _userCalendarDayService.GetByDateAsync(email, dateTime);
            return CreateResponse(response);
        }
    }
}