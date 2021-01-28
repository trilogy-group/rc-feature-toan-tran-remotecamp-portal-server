using Hangfire.Dashboard;

namespace RemoteCamp.Portal.Web
{
    public class DashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return context.IsReadOnly;
        }
    }
}