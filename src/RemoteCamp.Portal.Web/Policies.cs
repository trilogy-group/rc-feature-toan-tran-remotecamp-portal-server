using System;
using Microsoft.AspNetCore.Authorization;
using RemoteCamp.Portal.Core.Infrastructure.Security;

namespace RemoteCamp.Portal.Web
{
    public static class Policies
    {
        public const string Admin = "Admin";
        public const string ActiveOrFormerStudent = "ActiveOrFormerStudent";
        public const string Student = "Student";

        public static bool ActiveOrFormerStudentPolicyRequirement(AuthorizationHandlerContext context)
        {
            if (context.User.IsInRole(ApplicationRoles.Admin))
            {
                return true;
            }
            
            if (context.User.IsInRole(ApplicationRoles.Student))
            {
                var startDate = context.User.Claims.GetStartDate();
                return startDate.HasValue && DateTime.UtcNow.Date >= startDate.Value;
            }

            #pragma warning disable 0618
            if (context.User.IsInRole(ApplicationRoles.User))
            {
                return true;
            }
            
            return false;
        }
        
        public static bool StudentPolicyRequirement(AuthorizationHandlerContext context)
        {
            if (context.User.IsInRole(ApplicationRoles.Admin))
            {
                return true;
            }

            return context.User.IsInRole(ApplicationRoles.Student);
        }
        
        public static bool AdminPolicyRequirement(AuthorizationHandlerContext context)
        {
            return context.User.IsInRole(ApplicationRoles.Admin);
        }
    }
}