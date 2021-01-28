using System;
using RemoteCamp.Portal.Web.Core.Security;
using Shouldly;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Xunit;

namespace RemoteCamp.Portal.Web.Test.Core.Security
{
    public class JwtTokenFactoryTest
    {
        private const string NotBeforeClaim = "nbf";
        private const string ExpirationTimeClaim = "exp";
        private const string oldTokenString = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxz" +
                "b2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiVGVzdCBSQ01uZzAyIiwiaHR0cDovL3NjaGV" +
                "tYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJhcHBsaWNhdGl" +
                "vbi9jbGFpbXMvRW1haWwiOiJ0ZXN0cmNtbmcwMkBhdXJlYS5jb20iLCJuYmYiOjE2MTM1Mjk3NDgsImV4cCI6MTYxMzY" +
                "xNjE0OCwiaXNzIjoicmVtb3RldS50cmlsb2d5LmNvbSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6ODA4MC8ifQ.sX6" +
                "nalX7u4D1IfRQ4mr3nghpviW3FBsS7Pe5lPEQPg0";

        private readonly IJwtTokenFactory _jwtTokenFactory;

        public JwtTokenFactoryTest()
        {
            this._jwtTokenFactory = new JwtTokenFactory();
        }

        [Fact]
        public void Renew_ReturnRenewTokenWithCorrectExpireTime()
        {
            // Arrange
            var tokenHandler = new JwtSecurityTokenHandler();
            var oldToken = tokenHandler.ReadJwtToken(oldTokenString);

            // Act
            string renewTokenString = _jwtTokenFactory.Renew(oldTokenString);

            // Assert
            var newToken = tokenHandler.ReadJwtToken(renewTokenString);
            var oldTokenClaims = oldToken.Claims.OrderBy(c => c.Type).ToList();
            var newTokenClaims = newToken.Claims.OrderBy(c => c.Type).ToList();
            long oldExpireTime = Convert.ToInt64(oldTokenClaims.First(i => i.Type.Equals(ExpirationTimeClaim)).Value);
            long newExpireTime = Convert.ToInt64(newTokenClaims.First(i => i.Type.Equals(ExpirationTimeClaim)).Value);
            long newNotBefore = Convert.ToInt64(newTokenClaims.First(i => i.Type.Equals(NotBeforeClaim)).Value);

            List<Action> assertActions = new List<Action>() { 
                () => oldTokenClaims.Count.ShouldBe(newTokenClaims.Count),
                () => newExpireTime.ShouldBeGreaterThan(oldExpireTime, "new token have expiration time after old token"),
                () => newExpireTime.ShouldBeGreaterThan(DateTimeOffset.Now.ToUnixTimeSeconds(),
                                    "new token have expiration time after current time")
            };
            for (int i = 0; i < newTokenClaims.Count; i++)
            {
                if (!newTokenClaims[i].Type.Equals(ExpirationTimeClaim) &&
                    !newTokenClaims[i].Type.Equals(NotBeforeClaim))
                {
                    string claim = newTokenClaims[i].Type;
                    string newTokenClaimValue = newTokenClaims[i].Value;
                    string oldTokenClaimValue = oldTokenClaims[i].Value;
                    assertActions.Add(() => newTokenClaimValue.ShouldBe(oldTokenClaimValue, 
                                                            $"Claim {claim} values are not the same"));
                }
            }

            this.ShouldSatisfyAllConditions(assertActions.ToArray());
        }
    }
}
