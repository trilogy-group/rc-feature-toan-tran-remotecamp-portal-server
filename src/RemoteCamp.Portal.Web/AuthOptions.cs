using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace RemoteCamp.Portal.Web
{
    class AuthOptions
    {
        public const string ISSUER = "remoteu.trilogy.com";
        public const string AUDIENCE = "http://localhost:8080/";
        const string KEY = "mysupersecret_secretkey!123"; 
        public static readonly TimeSpan TokenLifeTime = TimeSpan.FromDays(1);
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
