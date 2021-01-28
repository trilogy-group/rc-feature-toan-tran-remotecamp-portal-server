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
    public class GradeBookController : ApplicationControllerBase
    {
        private readonly IGradeBookService _gradeBookService;
        private readonly ICacheService _cacheService;

        public GradeBookController(IGradeBookService gradeBookService, ICacheService cacheService)
        {
            _gradeBookService = gradeBookService ?? throw new ArgumentNullException(nameof(gradeBookService));
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
        }

        [HttpGet]
        public async Task<ActionResult<CachedGradeBook>> Get()
        {
            var response = await _cacheService.GetOrAddAsync(
                BusinessConstants.GradeBookEntityKey,
                () => AsyncUtil.RunSync(() => _gradeBookService.GetAllAsync()),
                CacheEntryOption.CreateMemoryCacheEntryOptions());
            return CreateResponse(response);
        }

    }
}