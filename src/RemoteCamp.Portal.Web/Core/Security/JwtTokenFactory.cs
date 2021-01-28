using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace RemoteCamp.Portal.Web.Core.Security
{
    public class JwtTokenFactory : IJwtTokenFactory
    {
        public string Create(ClaimsIdentity claimsIdentity)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: claimsIdentity.Claims,
                expires: now.Add(AuthOptions.TokenLifeTime),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public string Renew(string tokenString)
        {
            var now = DateTime.UtcNow;
            var tokenHandler = new JwtSecurityTokenHandler();
            var oldJwt = tokenHandler.ReadJwtToken(tokenString);
            var newJwt = new JwtSecurityToken(
                notBefore: now,
                claims: oldJwt.Claims,
                expires: now.Add(AuthOptions.TokenLifeTime),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return tokenHandler.WriteToken(newJwt);
        }
    }
}
