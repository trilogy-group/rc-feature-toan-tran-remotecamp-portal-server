using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using RemoteCamp.Portal.Core.Infrastructure.Caching;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public class CacheService : ICacheService
    {
        private readonly ICache _cache;

        public CacheService(ICache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetOrAddAsync<T>(string key, Func<T> loadCallback, MemoryCacheEntryOptions options = null)
        {
            return await _cache.GetOrAddAsync(key, loadCallback, options);
        }

        public void Set<T>(string key, T value, MemoryCacheEntryOptions options = null)
        {
            _cache.Set(key, value, options);
        }
    }
}
