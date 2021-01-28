using System.Collections.Generic;
using RemoteCamp.Portal.Core.Database.Model;

namespace RemoteCamp.Portal.Web.Models
{
    public class WeeklyPlanReviewSaveRequest
    {
        public string Email { get; set; }

        public IList<WeeklyPlanWeek> Plans { get; set; }
    }
}
