using System;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RemoteCamp.Portal.Core;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.Infrastructure.Data;
using RemoteCamp.Portal.Web.Core.Security;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteU.Component.NoSqlClient;
using Serilog;
using static RemoteCamp.Portal.Core.Infrastructure.Data.ApplicationOptions;
using Serilog.Sinks.SystemConsole.Themes;

namespace RemoteCamp.Portal.Web
{
    public class Startup
    {
        public static readonly string[] ProductionCorsOrigins =
        {
            "https://remoteu.trilogy.com",
            "https://staging-remoteu.trilogy.com",
            "https://staging-remoteu.webproxy.aureacentral.com" // TODO temporary
        };

        private static readonly string ProductionCorsPolicyName = "ProductionCorsPolicy";
        private static readonly string NonProductionCorsPolicyName = "NonProductionCorsPolicy";
        private static readonly string LogGroup = "Serilog:LogGroup";
        private static readonly string Stage = "Stage";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,

                        ValidateAudience = true,
                        ValidAudience = AuthOptions.AUDIENCE,

                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,

                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });


            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.ActiveOrFormerStudent, x => x.RequireAssertion(Policies.ActiveOrFormerStudentPolicyRequirement));
                options.AddPolicy(Policies.Student, x => x.RequireAssertion(Policies.StudentPolicyRequirement));
                options.AddPolicy(Policies.Admin, x => x.RequireAssertion(Policies.AdminPolicyRequirement));
            });

            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        NonProductionCorsPolicyName,
                        builder =>
                        {
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
                    options.AddPolicy(
                        ProductionCorsPolicyName,
                        builder =>
                        {
                            builder
                                .WithOrigins(ProductionCorsOrigins)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
                });

            var portalDbConnectionString = Configuration["RemoteUPortalDbConnectionString"] ??
                                           Configuration.GetConnectionString("DefaultConnection");

            var applicationOptions = new ApplicationOptions
            {
                GoogleApiEmail = Configuration["GoogleApiEmail"],
                GoogleApiPrivateKey = Configuration["GoogleApiPrivateKey"].Replace("\\n", "\n"),
                XoJiraUserName = Configuration["XoJiraUserName"],
                XoJiraPassword = Configuration["XoJiraPassword"],
                GithubAccessToken = Configuration["GithubAccessToken"],
                CrossoverUserName = Configuration["CrossoverUserName"],
                CrossoverPassword = Configuration["CrossoverPassword"],
                ItOpsOnBoardRequestUrl = Configuration.GetSection("ExternalServices")["ItOpsOnBoardRequestUrl"],
                DbConnectionString = portalDbConnectionString,
                IsProductionMode = true,
                JiraSettings = Configuration.GetSection("JiraSettings").Get<JiraSetting>(),
                SmtpSettings = Configuration.GetSection("SmtpSettings").Get<SmtpSetting>(),
                SmtpUserName = Configuration["SmtpUserName"],
                SmtpPassword = Configuration["SmtpPassword"],
                TicketBackupNoSqlDbConnectionString = Configuration["TicketBackupNoSqlDbConnectionString"],
                TicketBackupNoSqlDatabaseName = Configuration["TicketBackupNoSqlDatabaseName"]
            };

            services.AddPortalCoreServices();
            services.AddPortalCoreSqlServerDbContext(portalDbConnectionString);
            services.AddTransient<IJwtTokenFactory, JwtTokenFactory>()
                .AddTransient(x => (ApplicationOptions)applicationOptions.Clone());

            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMemoryStorage());
            services.AddNoSqlClient(options =>
            {
                options.ConnectionString = applicationOptions.TicketBackupNoSqlDbConnectionString;
                options.Database = applicationOptions.TicketBackupNoSqlDatabaseName;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IBackgroundJobClient backgroundJobs, IHostingEnvironment env)
        {
            if (env.IsEnvironment(Environments.Local))
            {
                Log.Logger = new LoggerConfiguration()
                                    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                                    .CreateLogger();
                Log.Logger.Information($"Application Started- {DateTime.UtcNow}");
            }
            else
            {
                CreateLoggerFromConfiguration(env.EnvironmentName);
            }

            if (env.IsDevelopment() || env.IsEnvironment(Environments.Local))
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSerilogRequestLogging();
            app.UseCors(
                env.IsProduction()
                    ? ProductionCorsPolicyName
                    : NonProductionCorsPolicyName);

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                Authorization = new[] { new DashboardAuthorizationFilter() },
                IsReadOnlyFunc = context => true
            });

            app.UseHangfireServer();
            app.UseMvc();

            RecurringJob.AddOrUpdate<JobFactory>(BusinessConstants.RecurringJobIdGradeBook,
                x => x.ExecuteGradeBookRecurringJob(),
                BusinessConstants.RunCronJobIntervalIn15Minute);
            RecurringJob.Trigger(BusinessConstants.RecurringJobIdGradeBook);

            RecurringJob.AddOrUpdate<JobFactory>(BusinessConstants.RecurringJobIdWeeklyPlanMissEmail,
                x => x.ExecuteWeeklyPlanMissedEmailSendingRecurringJob(),
                BusinessConstants.RunCronJobIntervalInTuesday9AM);
        }

        private void CreateLoggerFromConfiguration(string environment)
        {
            Configuration[LogGroup] = $"{environment}-RemoteUBackend";
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration).
                 WriteTo.AWSSeriLog(Configuration).CreateLogger();
            Log.Logger.Information($"Application Started- {DateTime.UtcNow}");
        }
    }
}
