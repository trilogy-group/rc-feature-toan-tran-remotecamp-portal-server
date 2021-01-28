using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public interface ICacheService
    {
        Task<T> GetOrAddAsync<T>(string key, Func<T> loadCallback, MemoryCacheEntryOptions options = null);
        void Set<T>(string key, T value, MemoryCacheEntryOptions options = null);
    }
}
