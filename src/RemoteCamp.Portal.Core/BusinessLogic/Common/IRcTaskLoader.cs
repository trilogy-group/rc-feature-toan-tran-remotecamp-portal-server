using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Data;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public interface IRcTaskLoader
    {
        Task<IList<RcTask>> LoadAsync(Profile profile);
    }
}