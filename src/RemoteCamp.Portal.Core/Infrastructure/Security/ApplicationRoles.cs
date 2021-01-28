using System;

namespace RemoteCamp.Portal.Core.Infrastructure.Security
{
    public static class ApplicationRoles
    {
        public const string Admin = "Admin";
        public const string Student = "Student";
        
        [Obsolete("It was left for backward compatibility.")]
        public const string User = "User";
    }
}
