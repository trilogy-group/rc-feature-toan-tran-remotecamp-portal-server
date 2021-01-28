using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class Score
    {
        public double? Approved { get; set; }
        public double? InReview { get; set; }
        public double? InProgress { get; set; }
        public double? TargetForToday { get; set; }
        public double? UltimateTarget { get; set; }
    }
}
