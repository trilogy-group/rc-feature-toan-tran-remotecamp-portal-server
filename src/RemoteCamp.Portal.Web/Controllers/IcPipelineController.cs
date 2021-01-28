using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Services;

namespace RemoteCamp.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IcPipelineController : ApplicationControllerBase
    {
        private readonly IIcPipelineService _icPipelineService;

        public IcPipelineController(IIcPipelineService icPipelineService)
        {
            _icPipelineService = icPipelineService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<IcPipeline>>> Get()
        {
            var response = await _icPipelineService.GetAllAsync();
            return CreateResponse(response);
        }
    }
}
