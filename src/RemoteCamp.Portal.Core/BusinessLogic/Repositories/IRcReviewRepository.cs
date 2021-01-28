using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Data;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public interface IRcReviewJiraRepository
    {
        Task<List<RcReview>> FindByRcTaskAsync(string rcTaskJiraKey);
    }
}