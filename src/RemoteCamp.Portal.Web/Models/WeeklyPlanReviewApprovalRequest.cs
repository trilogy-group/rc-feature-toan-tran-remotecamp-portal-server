using System.Collections.Generic;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.Database.Model;

namespace RemoteCamp.Portal.Web.Models
{
    public class WeeklyPlanReviewApprovalRequest
    {
        public string Email { get; set; }

        public bool IsApproved { get; set; }

        public StudyWeek WeekNumber { get; set; }
    }
}
