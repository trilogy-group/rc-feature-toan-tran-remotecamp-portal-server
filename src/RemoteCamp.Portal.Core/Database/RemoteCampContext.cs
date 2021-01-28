using System;
using Microsoft.EntityFrameworkCore;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Database.Model;

namespace RemoteCamp.Portal.Core.Database
{
    public class RemoteCampContext : DbContext
    {
        private readonly IDataSeed _dataSeed;

        public RemoteCampContext(IDataSeed dataSeed)
        {
            _dataSeed = dataSeed ?? throw new ArgumentNullException(nameof(dataSeed));
        }

        public RemoteCampContext(DbContextOptions<RemoteCampContext> options, IDataSeed dataSeed) : base(options)
        {
            _dataSeed = dataSeed;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserCalendarItemAction> UserCalendarItemActions { get; set; }
        public DbSet<UserCalendarItem> UserCalendarItems { get; set; }
        public DbSet<UserCalendarItemStatus> UserCalendarItemStatus { get; set; }
        public DbSet<Pipeline> Pipelines { get; set; }
        public DbSet<PipelinePrerequisite> PipelinePrerequisites { get; set; }

        public DbSet<UserCheckInChatItem> UserCheckInChatItem { get; set; }
        public DbSet<UserCheckInChatItemStatus> UserCheckInChatItemStatus { get; set; }
        public DbSet<WeeklyPlanWeek> WeeklyPlanWeeks { get; set; }
        public DbSet<WeeklyPlanDay> WeeklyPlanDays { get; set; }
        public DbSet<ApiKey> ApiKeys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCalendarItem>().HasData(_dataSeed.GetUserCalendarItems());
            modelBuilder.Entity<UserCalendarItemAction>().HasData(_dataSeed.GetUserCalendarItemActions());
            modelBuilder.Entity<UserCheckInChatItem>().HasData(_dataSeed.GetUserCheckInChatItem());
            modelBuilder.Entity<Pipeline>().HasData(_dataSeed.GetPipelines());
            modelBuilder.Entity<PipelinePrerequisite>().HasData(_dataSeed.GetPipelinePrerequisites());
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
