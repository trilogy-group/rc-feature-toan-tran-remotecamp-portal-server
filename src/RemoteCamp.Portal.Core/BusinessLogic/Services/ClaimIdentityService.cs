using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.Data;
using RemoteCamp.Portal.Core.Infrastructure.Google;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using RemoteCamp.Portal.Core.Infrastructure.Security;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Core.Utils;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    class ClaimIdentityService : IClaimIdentityService
    {
        private readonly IGoogleJsonWebSignatureAdapter _googleJsonWebSignatureAdapter;
        private readonly IJiraUserRepository _jiraUserRepository;
        private readonly IErTicketRepository _erTicketRepository;
        private readonly IApiKeyRepository _apiKeyRepository;
        private readonly ApplicationOptions _applicationOptions;

        public ClaimIdentityService(IGoogleJsonWebSignatureAdapter googleJsonWebSignatureAdapter,
            IJiraUserRepository jiraUserRepository,
            IErTicketRepository erTicketRepository,
            IApiKeyRepository apiKeyRepository,
            ApplicationOptions applicationOptions)
        {
            _googleJsonWebSignatureAdapter = googleJsonWebSignatureAdapter;
            _jiraUserRepository = jiraUserRepository;
            _erTicketRepository = erTicketRepository;
            _apiKeyRepository = apiKeyRepository;
            _applicationOptions = applicationOptions;
        }

        public async Task<ServiceValueResponse<ClaimsIdentity>> CreateFromGoogleAccountAsync(string googleToken)
        {
            if (!TryValidateGoogleToken(googleToken, out var tokenPayload)
                || tokenPayload == null
                || !tokenPayload.EmailVerified)
            {
                return ServiceValueResponse<ClaimsIdentity>.Error(ErrorCodes.InvalidGoogleToken, "Invalid Google Token");
            }

            return await CreateClaimsIdentity(tokenPayload.Email);
        }

        public async Task<ServiceValueResponse<ClaimsIdentity>> CreateFromApiKey(ApiKey apiKey)
            {
            var result = await _apiKeyRepository.GetActiveApiKeyAsync(apiKey.Email, apiKey.Key);

            if (result == null)
            {
                return ServiceValueResponse<ClaimsIdentity>.Error(ErrorCodes.InvalidApiKey, "Invalid Api Key");
            }

            return await CreateClaimsIdentity(apiKey.Email);
        }

        public async Task<ServiceValueResponse<ClaimsIdentity>> CreateImpersonatedAsync(ClaimsIdentity claimsIdentity, string email)
        {
            var impersonationClaim = new Claim(ApplicationSecurityClaims.Impersonator, claimsIdentity.Claims.GetEmail());
            return await CreateClaimsIdentity(email, additionalClaim: impersonationClaim);
        }

        private async Task<ServiceValueResponse<ClaimsIdentity>> CreateClaimsIdentity(string email, Claim additionalClaim = null)
        {
            var erTicket = await _erTicketRepository.GetByCompanyEmailAsync(email);

            var jiraUser = await _jiraUserRepository.GetByEmailAsync(email, JiraUserLoadOptions.Groups);

            if (erTicket == null && jiraUser == null)
            {
                return ServiceValueResponse<ClaimsIdentity>.Error(ErrorCodes.UserWasNotFound, "User not exists");
            }

            string role = null;
            DateTime? startDate = null;

            if (erTicket != null)
            {
                role = ApplicationRoles.Student;
                startDate = erTicket.StartDate;
            }

            if (jiraUser != null)
            {
                startDate = null;
                role = GetRole(jiraUser, erTicket);
                switch (role)
                {
                    case null:
                        return ServiceValueResponse<ClaimsIdentity>.Error(ErrorCodes.UserRoleWasNotDetermined, "User not exists");
                    case ApplicationRoles.Student when erTicket == null:
                        return ServiceValueResponse<ClaimsIdentity>.Error(ErrorCodes.NotFound, "User dose not exists in ER jira project.");
                    case ApplicationRoles.Student:
                    {
                        startDate = erTicket.StartDate;
                        break;
                    }
                }
            }

            var userName = jiraUser?.DisplayName ?? erTicket.Name;
            var claims = CreateStandardClaims(name: userName, email: email, role: role, startDate: startDate);
            if (additionalClaim != null)
            {
                claims.Add(additionalClaim);
            }

            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            return ServiceValueResponse<ClaimsIdentity>.Success(claimsIdentity);
        }

        private List<Claim> CreateStandardClaims(string name, string email, string role, DateTime? startDate)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role),
                new Claim(ApplicationSecurityClaims.Email, email)
            };

            if (startDate.HasValue)
            {
                var unixTime = new DateTimeOffset(startDate.Value).ToUnixTimeMilliseconds();
                claims.Add(new Claim(ApplicationSecurityClaims.StartDate, unixTime.ToString()));
            }

            return claims;
        }

        private string GetRole(JiraUser jiraUser, ErTicket erTicket)
        {
            if (jiraUser == null && erTicket == null)
            {
                return null;
            }

            if (jiraUser == null)
            {
                return ApplicationRoles.Student;
            }

            var jiraGroups = jiraUser.Groups ?? Enumerable.Empty<string>();
            var isInAdminJiraGroups = jiraGroups.Any(x =>
                                          x.Equals(_applicationOptions.JiraSettings.ManagementJiraGroup,
                                              StringComparison.OrdinalIgnoreCase)) ||
                                      jiraGroups.Any(x => x.Equals(_applicationOptions.JiraSettings.QeJiraGroup,
                                          StringComparison.OrdinalIgnoreCase)) ||
                                      jiraGroups.Any(x => x.Equals(_applicationOptions.JiraSettings.WatchersJiraGroup,
                                          StringComparison.OrdinalIgnoreCase));
            if (isInAdminJiraGroups)
            {
                return ApplicationRoles.Admin;
            }

            var isInStudentJiraGroup = jiraGroups.Any(x =>
                x.Equals(_applicationOptions.JiraSettings.StudentJiraGroup, StringComparison.OrdinalIgnoreCase));
            if (isInStudentJiraGroup || erTicket != null)
            {
                return ApplicationRoles.Student;
            }

            return null;
        }

        private bool TryValidateGoogleToken(string googleToken, out GoogleJsonWebSignature.Payload tokenPayload)
        {
            try
            {
                tokenPayload = AsyncUtil.RunSync(() => _googleJsonWebSignatureAdapter.ValidateAsync(googleToken));
                return true;
            }
            catch (InvalidJwtException)
            {
                tokenPayload = null;
                return false;
            }
        }
    }
}
