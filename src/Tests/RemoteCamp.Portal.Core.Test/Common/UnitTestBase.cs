using System;
using RemoteCamp.Portal.Core.Infrastructure.Common;

namespace RemoteCamp.Portal.Core.Test.Common
{
    public class UnitTestBase
    {
        public UnitTestBase()
        {
            ServiceProvider = new MockServiceProvider();
        }

        protected IMockServiceProvider ServiceProvider { get; }

        protected void MockTimeService(DateTime utcNow)
        {
             ServiceProvider.GetMock<ITimeService>()
                 .SetupGet(x => x.UtcNow)
                 .Returns(utcNow);
        }
    }
}