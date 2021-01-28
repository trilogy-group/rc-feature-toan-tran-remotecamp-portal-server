using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace RemoteCamp.Portal.Core.Infrastructure.Caching
{
    public class Cache : ICache
    {
        private readonly IMemoryCache _memoryCache;

        public Cache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<T> GetOrAddAsync<T>(string key, Func<T> loadCallback, MemoryCacheEntryOptions options = null)
        {
            var cacheEntry = await _memoryCache.GetOrCreateAsync(key, entry =>
              {
                  entry.SetOptions(options);
                  return Task.FromResult(loadCallback());
              });
            return cacheEntry;
        }

        public void Set<T>(string key, T value, MemoryCacheEntryOptions options = null)
        {
            var item = _memoryCache.Get(key);
            if (item != null)
            {
                _memoryCache.Remove(key);
            }
            _memoryCache.Set(key, value, options);
        }
    }
}
