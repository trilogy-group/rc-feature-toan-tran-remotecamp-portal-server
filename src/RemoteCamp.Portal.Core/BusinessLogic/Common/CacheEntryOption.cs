using System;
using Microsoft.Extensions.Caching.Memory;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public static class CacheEntryOption
    {
        public static MemoryCacheEntryOptions CreateMemoryCacheEntryOptions()
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                          .SetPriority(CacheItemPriority.NeverRemove)
                          .SetAbsoluteExpiration(TimeSpan.FromMinutes(BusinessConstants.CacheExpirationTimeInMinute))
                          .SetSlidingExpiration(TimeSpan.FromMinutes(BusinessConstants.CacheExpirationTimeInMinute));
            return cacheEntryOptions;
        }

    }
}
