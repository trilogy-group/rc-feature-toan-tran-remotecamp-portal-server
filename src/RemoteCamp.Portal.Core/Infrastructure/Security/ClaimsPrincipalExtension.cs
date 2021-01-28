using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace RemoteCamp.Portal.Core.Infrastructure.Security
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetEmail(this IEnumerable<Claim> claims)
        {
            return claims.First(x => x.Type == ApplicationSecurityClaims.Email).Value;
        }

        public static DateTime? GetStartDate(this IEnumerable<Claim> claims)
        {
            var startDateClaim = claims.FirstOrDefault(x => x.Type == ApplicationSecurityClaims.StartDate);
            if (startDateClaim == null)
            {
                return null;
            }

            return DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(startDateClaim.Value)).LocalDateTime;
        }
    }
}
