using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Database;
using RemoteCamp.Portal.Core.Infrastructure.Caching;
using RemoteCamp.Portal.Core.Infrastructure.Common;
using RemoteCamp.Portal.Core.Infrastructure.Crossover;
using RemoteCamp.Portal.Core.Infrastructure.Email;
using RemoteCamp.Portal.Core.Infrastructure.GitHub;
using RemoteCamp.Portal.Core.Infrastructure.Google;
using RemoteCamp.Portal.Core.Infrastructure.ItOpsOnBoard;
using RemoteCamp.Portal.Core.Infrastructure.Jira;

namespace RemoteCamp.Portal.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPortalCoreServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddTransient<IClaimIdentityService, ClaimIdentityService>()
                .AddTransient<IGoogleSheetServiceAdapter, GoogleSheetServiceAdapter>()
                .AddTransient<IGoogleJsonWebSignatureAdapter, GoogleJsonWebSignatureAdapter>()
                .AddTransient<ITimeService, TimeService>()
                .AddTransient<IJiraClientAdapter, JiraClientAdapter>()
                .AddTransient<IGitHubClientAdapter, GitHubClientAdapter>()
                .AddTransient<IProfileService, ProfileService>()
                .AddTransient<IProfileAccomplishmentsService, ProfileAccomplishmentsService>()
                .AddTransient<IProfileHardestProblemService, ProfileHardestProblemService>()
                .AddTransient<IProfileCrnFindingService, ProfileCrnFindingService>()
                .AddTransient<IErTicketRepository, ErTicketRepository>()
                .AddTransient<IJiraUserRepository, JiraUserRepository>()
                .AddTransient<IRcTaskJiraRepository, RcTaskJiraRepository>()
                .AddTransient<IRcReviewJiraRepository, RcReviewJiraRepository>()
                .AddTransient<IPullRequestRepository, PullRequestRepository>()
                .AddTransient<IIcPipelineRepository, IcPipelineRepository>()
                .AddTransient<IScoreCalculator, ScoreCalculator>()
                .AddTransient<IFtarCalculator, FtarCalculator>()
                .AddTransient<IProfileHardestProblemByDayService, ProfileHardestProblemByDayService>()
                .AddTransient<IProfileUserCalendarItemStatusRepository, ProfileUserCalendarItemStatusRepository>()
                .AddTransient<IProfileUserCalendarService, ProfileUserCalendarService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IGradeBookService, GradeBookService>()
                .AddTransient<ICacheService, CacheService>()
                .AddTransient<IIcPipelineService, IcPipelineService>()
                .AddTransient<IRegistrationService, RegistrationService>()
                .AddTransient<ICache, Cache>()
                .AddTransient<IJobFactory, JobFactory>()
                .AddTransient<IProfileUserCheckInChatService, ProfileUserCheckInChatService>()
                .AddTransient<IProfileUserCheckInChatRepository, ProfileUserCheckInChatRepository>()
                .AddTransient<ICrossoverClient, CrossoverClient>()
                .AddTransient<IProfileUserComplianceRepository, ProfileUserComplianceRepository>()
                .AddTransient<IProfileUserComplianceService, ProfileUserComplianceService>()
                .AddSingleton<IMemoryCache, MemoryCache>()
                .AddTransient<IItOpsOnBoardAdapter, ItOpsOnBoardAdapter>()
                .AddSingleton<IDataSeed>(new DataSeed())
                .AddTransient<IWeeklyPlanDayRepository, WeeklyPlanDayRepository>()
                .AddTransient<IWeeklyPlanWeekRepository, WeeklyPlanWeekRepository>()
                .AddTransient<IWeeklyPlanService, WeeklyPlanService>()
                .AddTransient<IEmailService, EmailService>()
                .AddTransient<IEmailAlertService, EmailAlertService>()
                .AddTransient<IApiKeyRepository, ApiKeyRepository>()
                .AddTransient<IHardestProblemService, HardestProblemService>()
                .AddTransient<IRcTaskLoader, RcTaskLoader>()
                .AddTransient<ITemplater, Templater>()
                .AddTransient<IUserCalendarItemRepository, UserCalendarItemRepository>()
                .AddTransient<IUserCalendarDayService, UserCalendarDayService>()
                .AddTransient<IQualityTargetProvider, QualityTargetProvider>();
        }

        public static void AddPortalCoreSqlServerDbContext(this IServiceCollection serviceCollection, string connection)
        {
            serviceCollection.AddDbContext<RemoteCampContext>(
                options => options.UseSqlServer(
                    connection,
                    builder => builder.MigrationsAssembly("RemoteCamp.Portal.Core")));
        }
    }
}
