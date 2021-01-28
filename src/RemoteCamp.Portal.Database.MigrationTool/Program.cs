using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Database;

namespace RemoteCamp.Portal.Database.MigrationTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = args[0];

            var serviceProvider = new ServiceCollection().AddLogging(
                builder => { builder.AddConsole().SetMinimumLevel(LogLevel.Information); }).BuildServiceProvider();
            
            var dboContextOptions = new DbContextOptionsBuilder<RemoteCampContext>();
            dboContextOptions.UseSqlServer(connectionString);
            dboContextOptions.UseLoggerFactory(serviceProvider.GetService<ILoggerFactory>());

            using (var context = new RemoteCampContext(dboContextOptions.Options, new DataSeed()))
            {
                context.Database.Migrate();
            }
        }
    }
}
