using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using Google.Apis.Auth;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Data;
using RemoteCamp.Portal.Core.Infrastructure.Google;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Core.Test.Common;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Services
{
    public class ClaimIdentityServiceTest : UnitTestBase
    {
        private readonly ClaimIdentityService _claimIdentityService;

        public ClaimIdentityServiceTest()
        {
            _claimIdentityService = ServiceProvider.GetService<ClaimIdentityService>();
        }

        [Theory]
        [InlineData("Student", new[] { "remotecamp" })]
        [InlineData("Student", new string[0])]
        [InlineData("Admin", new[] { "remotecamp-qe" })]
        [InlineData("Admin", new[] { "remotecamp-management" })]
        [InlineData("Admin", new[] { "remotecamp", "remotecamp-management" })]
        [InlineData("Admin", new[] { "remotecamp", "remotecamp-qe" })]
        public async void CreateFromGoogleAccountAsync_ValidToken_ReturnsClaims(string expectedRole, string[] jiraGroups)
        {
            var token = "testToken";
            var displayName = "John Snow";
            var email = "jon.snow@mail.test";
            var userName = "jon.snow";
            var groups = jiraGroups.ToList();
            var erTicket = CreateErTicketObject();
            var startDate = erTicket.StartDate.Value;
            SetApplicationOptionsValue();
            ServiceProvider.GetMock<IGoogleJsonWebSignatureAdapter>()
                .Setup(x => x.ValidateAsync(token))
                .ReturnsAsync(
                    new GoogleJsonWebSignature.Payload
                    {
                        Email = email,
                        EmailVerified = true
                    });

            ServiceProvider.GetMock<IErTicketRepository>()
                .Setup(x => x.GetByCompanyEmailAsync(email, ErTicketLoadOptions.None))
                .ReturnsAsync(erTicket);

            ServiceProvider.GetMock<IUserService>()
                .Setup(x => x.GetOrCreateByEmailAsync(erTicket.CompanyEmail))
                .ReturnsAsync(ServiceValueResponse<User>.Success(new User()));

            CreateMocksThatReturnsUser(email, userName, displayName, groups);

            var result = await _claimIdentityService.CreateFromGoogleAccountAsync(token);

            result.IsSuccess.ShouldBeTrue();
            this.ShouldSatisfyAllConditions(
                () => result.Value.HasClaim(ClaimsIdentity.DefaultNameClaimType, displayName).ShouldBeTrue(),
                () => result.Value.HasClaim(ClaimsIdentity.DefaultRoleClaimType, expectedRole).ShouldBeTrue(),
                () => result.Value.HasClaim("application/claims/Email", email).ShouldBeTrue()
                );

            if (expectedRole == "Student")
            {
                var unixTime = new DateTimeOffset(startDate).ToUnixTimeMilliseconds();
                result.Value.HasClaim("application/claims/StartDate", unixTime.ToString()).ShouldBeTrue();
            }
        }

        [Fact]
        public async void CreateFromGoogleAccountAsync_JiraUserButErTicketNotExists_ReturnsAdminRole()
        {
            var token = "testToken";
            var displayName = "John Snow";
            var email = "jon.snow@mail.test";
            var userName = "jon.snow";
            var groups = new List<string> { "remotecamp-qe" };
            SetApplicationOptionsValue();

            ServiceProvider.GetMock<IGoogleJsonWebSignatureAdapter>()
                .Setup(x => x.ValidateAsync(token))
                .ReturnsAsync(
                    new GoogleJsonWebSignature.Payload
                    {
                        Email = email,
                        EmailVerified = true
                    });

            CreateMocksThatReturnsUser(email, userName, displayName, groups);

            var result = await _claimIdentityService.CreateFromGoogleAccountAsync(token);

            result.IsSuccess.ShouldBeTrue();
            this.ShouldSatisfyAllConditions(
                () => result.Value.HasClaim(ClaimsIdentity.DefaultNameClaimType, displayName).ShouldBeTrue(),
                () => result.Value.HasClaim(ClaimsIdentity.DefaultRoleClaimType, "Admin").ShouldBeTrue(),
                () => result.Value.HasClaim("application/claims/Email", email).ShouldBeTrue()
            );
        }


        [Fact]
        public async void CreateFromGoogleAccountAsync_StagedErTicketButJiraUserNotExists_ReturnsStudentRole()
        {
            var token = "testToken";
            var email = "jon.snow@mail.test";
            var erTicket = CreateErTicketObject(status: "Staged");
            var startDate = erTicket.StartDate.Value;

            ServiceProvider.GetMock<IGoogleJsonWebSignatureAdapter>()
                .Setup(x => x.ValidateAsync(token))
                .ReturnsAsync(
                    new GoogleJsonWebSignature.Payload
                    {
                        Email = email,
                        EmailVerified = true
                    });

            ServiceProvider.GetMock<IErTicketRepository>()
                .Setup(x => x.GetByCompanyEmailAsync(email, ErTicketLoadOptions.None))
                .ReturnsAsync(erTicket);

            var result = await _claimIdentityService.CreateFromGoogleAccountAsync(token);

            result.IsSuccess.ShouldBeTrue();

            var unixTime = new DateTimeOffset(startDate).ToUnixTimeMilliseconds();
            this.ShouldSatisfyAllConditions(
                () => result.Value.HasClaim(ClaimsIdentity.DefaultNameClaimType, erTicket.Name).ShouldBeTrue(),
                () => result.Value.HasClaim(ClaimsIdentity.DefaultRoleClaimType, "Student").ShouldBeTrue(),
                () => result.Value.HasClaim("application/claims/Email", email).ShouldBeTrue(),
                () => result.Value.HasClaim("application/claims/StartDate", unixTime.ToString()).ShouldBeTrue()
            );
        }

        [Fact]
        public async void CreateFromGoogleAccountAsync_EmptyGroups_ReturnsError()
        {
            var token = "testToken";
            var displayName = "John Snow";
            var email = "jon.snow@mail.test";
            var userName = "jon.snow";

            ServiceProvider.GetMock<IGoogleJsonWebSignatureAdapter>()
                .Setup(x => x.ValidateAsync(token))
                .ReturnsAsync(
                    new GoogleJsonWebSignature.Payload
                    {
                        Email = email,
                        EmailVerified = true
                    });

            CreateMocksThatReturnsUser(email, userName, displayName, null);

            var result = await _claimIdentityService.CreateFromGoogleAccountAsync(token);

            result.IsSuccess.ShouldBeFalse();
            result.Errors.ShouldContain(x => x.Code == ErrorCodes.UserRoleWasNotDetermined);
        }

        [Fact]
        public async void CreateFromApiKeyAsync_ReturnsClaims()
        {
            var token = "PamclpFaATdE2Rj1Lbky7yeBdE3xJCfW";
            var email = "jon.snow@mail.test";
            var displayName = "John Snow";
            var userName = "jon.snow";
            var groups = new List<string> { "remotecamp-qe" };
            var userId = 1;
            var id = 1;
            SetApplicationOptionsValue();

            var apiKeyRequest = new RemoteCamp.Portal.Core.BusinessLogic.Data.ApiKey {
                Email = email,
                Key = token
            };
            ServiceProvider.GetMock<IApiKeyRepository>()
                .Setup(x => x.GetActiveApiKeyAsync(email, token))
                .ReturnsAsync(
                    new RemoteCamp.Portal.Core.Database.Model.ApiKey
                    {
                        Id = id,
                        UserId = userId,
                        Key = token,
                        IsActive = true
                    });
            CreateMocksThatReturnsUser(email, userName, displayName, groups);

            var result = await _claimIdentityService.CreateFromApiKey(apiKeyRequest);

            result.IsSuccess.ShouldBeTrue();
            this.ShouldSatisfyAllConditions(
                () => result.Value.HasClaim(ClaimsIdentity.DefaultNameClaimType, displayName).ShouldBeTrue(),
                () => result.Value.HasClaim(ClaimsIdentity.DefaultRoleClaimType, "Admin").ShouldBeTrue(),
                () => result.Value.HasClaim("application/claims/Email", email).ShouldBeTrue()
            );
        }

        [Fact]
        public async void CreateFromApiKeyAsync_ReturnsError()
        {
            var token = "PamclpFaATdE2Rj1Lbky7yeBdE3xJCfW";
            var email = "jon.snow@mail.test";

            SetApplicationOptionsValue();

            var apiKeyRequest = new RemoteCamp.Portal.Core.BusinessLogic.Data.ApiKey
            {
                Email = email,
                Key = token
            };
            ServiceProvider.GetMock<IApiKeyRepository>()
                .Setup(x => x.GetActiveApiKeyAsync(email, token))
                .ReturnsAsync(
                    new RemoteCamp.Portal.Core.Database.Model.ApiKey { });

            var result = await _claimIdentityService.CreateFromApiKey(apiKeyRequest);
            result.IsSuccess.ShouldBeFalse();
            result.ContainsErrorCode(ErrorCodes.InvalidApiKey);
        }
        private void CreateMocksThatReturnsUser(
            string email,
            string accountId,
            string displayName,
            List<string> groups)
        {
            ServiceProvider.GetMock<IJiraUserRepository>()
                .Setup(x => x.GetByEmailAsync(email, JiraUserLoadOptions.Groups))
                .ReturnsAsync(
                    new JiraUser
                    {
                        Email = email,
                        AccountId = accountId,
                        DisplayName = displayName,
                        Groups = groups
                    });
        }

        private void SetApplicationOptionsValue()
        {
            var applicationOption = new ApplicationOptions();
            applicationOption.JiraSettings.AssignmentsProject = "REM";
            applicationOption.JiraSettings.IcCardProject = "ER";
            applicationOption.JiraSettings.StudentJiraGroup = "RemoteCamp";
            applicationOption.JiraSettings.QeJiraGroup = "RemoteCamp-QE";
            applicationOption.JiraSettings.ManagementJiraGroup = "RemoteCamp-management";
            applicationOption.JiraSettings.WatchersJiraGroup = "RemoteCamp-watchers";
            var field = typeof(ClaimIdentityService).GetField("_applicationOptions", BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(_claimIdentityService, applicationOption);
        }

        private static ErTicket CreateErTicketObject(string status = "RC Active")
        {
            return new ErTicket
            {
                Assignee = new JiraUserValue
                {
                    AccountId = "test"
                },
                DeckUrl = "http://test.deckurl",
                JiraKey = "REM-121",
                Pipeline = "C# (.NET) Software Engineer",
                RcJiraId = "absc1234",
                RcXoId = 1,
                StartDate = DateTime.UtcNow,
                Status = status,
                Summary = "Test User",
                Name = "test user",
                TmsUrl = "http://tms.url",
                CompanyEmail = "jon.snow@mail.test"
            };
        }
    }
}
