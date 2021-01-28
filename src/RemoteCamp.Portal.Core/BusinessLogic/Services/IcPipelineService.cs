using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    class IcPipelineService : IIcPipelineService
    {
        private readonly IIcPipelineRepository _icPipelineRepository;

        public IcPipelineService(IIcPipelineRepository icPipelineRepository)
        {
            _icPipelineRepository = icPipelineRepository;
        }

        public async Task<ServiceValueResponse<IList<IcPipeline>>> GetAllAsync()
        {
            var icPipelines = await _icPipelineRepository.GetAllAsync();
            return ServiceValueResponse<IList<IcPipeline>>.Success(icPipelines);
        }
    }
}
