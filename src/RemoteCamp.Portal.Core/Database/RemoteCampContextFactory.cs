using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;

namespace RemoteCamp.Portal.Core.Database
{
    public class RemoteCampContextFactory : IDesignTimeDbContextFactory<RemoteCampContext>
    {
        public RemoteCampContext CreateDbContext(string[] args)
        {
            Console.WriteLine($"RemoteCampContextFactory: Current directory {Directory.GetCurrentDirectory()}");
            var solutionPath = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            var appSettingsPath = Path.Combine(solutionPath, "RemoteCamp.Portal.Web", "appsettings.json");
            Console.WriteLine($"RemoteCampContextFactory: Tries to use {appSettingsPath}");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(appSettingsPath)
                .Build();
            
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"RemoteCampContextFactory: Connection String = {connectionString}");
            
            var optionsBuilder = new DbContextOptionsBuilder<RemoteCampContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new RemoteCampContext(optionsBuilder.Options, new DataSeed());
        }
    }
}