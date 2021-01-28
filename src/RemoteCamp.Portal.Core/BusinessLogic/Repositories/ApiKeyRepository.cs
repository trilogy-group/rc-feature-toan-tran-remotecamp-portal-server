using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteCamp.Portal.Core.Database;
using ApiKey = RemoteCamp.Portal.Core.Database.Model.ApiKey;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public class ApiKeyRepository : GenericRepository<ApiKey>, IApiKeyRepository
    {
        public ApiKeyRepository(RemoteCampContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<ApiKey> GetActiveApiKeyAsync(string email, string key)
        {
            var query = from apiKey in DbContext.ApiKeys
                         join user in DbContext.Users
                         on apiKey.UserId equals user.Id
                         where user.Email == email
                         && apiKey.Key == key
                         && apiKey.IsActive
                         select apiKey;

            var result = await query.ToArrayAsync();
            return result.FirstOrDefault(x => x.Key == key);
        }
    }
}
