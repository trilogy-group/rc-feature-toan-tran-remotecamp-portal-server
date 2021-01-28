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
    public class ProfileAccomplishmentsController : ApplicationControllerBase
    {
        private readonly IProfileAccomplishmentsService _profileAccomplishmentsService;

        public ProfileAccomplishmentsController(IProfileAccomplishmentsService profileAccomplishmentsService)
        {
            _profileAccomplishmentsService = profileAccomplishmentsService;
        }

        [HttpGet]
        public async Task<ActionResult<ProfileAccomplishments>> Get()
        {
            var email = User.Claims.GetEmail();
            var response = await _profileAccomplishmentsService.GetAsync(email);
            return CreateResponse(response);
        }

        [HttpGet("{email}")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<ActionResult<ProfileAccomplishments>> Get(string email)
        {
            var response = await _profileAccomplishmentsService.GetAsync(email);
            return CreateResponse(response);
        }
    }
}