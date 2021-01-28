namespace RemoteCamp.Portal.Core.Infrastructure.Security
{
    public static class ApplicationSecurityClaims
    {
        public static readonly string Email = "application/claims/Email";
        public static readonly string StartDate = "application/claims/StartDate";
        public static readonly string Impersonator = "application/claims/Impersonator";
        public static readonly string RcXoIdName = "application/claims/RcXoId";
    }
}
