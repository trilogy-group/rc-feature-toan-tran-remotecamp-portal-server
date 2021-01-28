using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RemoteCamp.Portal.Core.Infrastructure.Caching
{
    public interface ICache
    {
        Task<T> GetOrAddAsync<T>(string key, Func<T> loadCallback, MemoryCacheEntryOptions options = null);
        void Set<T>(string key, T value, MemoryCacheEntryOptions options = null);
    }
}
