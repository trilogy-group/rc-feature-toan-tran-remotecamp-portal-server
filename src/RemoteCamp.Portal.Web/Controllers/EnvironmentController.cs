using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RemoteCamp.Portal.Core.Infrastructure.Data;
using RemoteCamp.Portal.Core.Infrastructure.Security;

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = Policies.Admin)]
    public class EnvironmentController : ApplicationControllerBase
    {
        private readonly ApplicationOptions _applicationOptions;

        public EnvironmentController(ApplicationOptions applicationOptions)
        {
            _applicationOptions = applicationOptions;
        }

        [HttpGet]
        public ActionResult<dynamic> Get()
        {
            return new
            {
                options = _applicationOptions
            };
        }
    }
}
