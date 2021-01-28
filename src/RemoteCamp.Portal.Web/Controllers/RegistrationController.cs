using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Web.Utils;

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ApplicationControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<ActionResult> Post(IFormFile contract, [FromForm]string signUpData)
        {
            var registrationCreateRequest = JsonConvert.DeserializeObject<RegistrationCreateRequest>(signUpData);
            registrationCreateRequest.SignedContract = contract.ReadBytes();

            var response = await _registrationService.CreateAsync(registrationCreateRequest);

            return CreateResponse(response);
        }
    }
}
