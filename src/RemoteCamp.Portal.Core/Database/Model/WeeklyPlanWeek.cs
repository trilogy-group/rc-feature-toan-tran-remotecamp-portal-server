using System;
using System.Collections.Generic;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;

namespace RemoteCamp.Portal.Core.Database.Model
{
    public class WeeklyPlanWeek
    {
        public int Id { get; set; }

        public StudyWeek WeekNumber { get; set; }

        public bool Submitted { get; set; }

        public bool Approved { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public IList<WeeklyPlanDay> Week { get; set; }
    }
}
