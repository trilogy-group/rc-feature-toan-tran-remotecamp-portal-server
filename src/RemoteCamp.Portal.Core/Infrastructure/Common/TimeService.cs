using System;

namespace RemoteCamp.Portal.Core.Infrastructure.Common
{
    public class TimeService : ITimeService
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
