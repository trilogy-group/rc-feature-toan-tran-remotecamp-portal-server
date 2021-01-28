using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Data;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public interface IIcPipelineRepository
    {
        Task<IList<IcPipeline>> GetAllAsync();
        Task<IcPipeline> GetAsync(int id);
    }
}