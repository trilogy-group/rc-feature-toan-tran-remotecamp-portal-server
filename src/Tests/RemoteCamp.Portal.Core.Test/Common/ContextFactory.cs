using Microsoft.EntityFrameworkCore;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Database;

namespace RemoteCamp.Portal.Core.Test.Helpers
{
    public static class ContextFactory
    {
        public static RemoteCampContext CreateContext(bool withData)
        {
            var options = new DbContextOptionsBuilder<RemoteCampContext>()
                .UseInMemoryDatabase("RemoteCampUnitTestsDb")
                .Options;
            var context = new RemoteCampContext(options, new DataSeed());
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }
    }
}
