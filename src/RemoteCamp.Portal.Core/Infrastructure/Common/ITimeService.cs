using System;

namespace RemoteCamp.Portal.Core.Infrastructure.Common
{
    public interface ITimeService
    {
        DateTime UtcNow { get; }
    }
}