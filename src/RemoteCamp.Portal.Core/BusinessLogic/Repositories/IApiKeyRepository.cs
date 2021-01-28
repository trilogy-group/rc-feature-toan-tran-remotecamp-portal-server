using System.Threading.Tasks;
using ApiKey = RemoteCamp.Portal.Core.Database.Model.ApiKey;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public interface IApiKeyRepository
    {
        Task<ApiKey> GetActiveApiKeyAsync(string email, string key);
    }
}
