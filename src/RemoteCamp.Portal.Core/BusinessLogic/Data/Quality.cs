using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class Quality
    {
        public double? Approved { get; set; }
        public double? ApprovedAndInReview { get; set; }
        public double? TargetForToday { get; set; }
    }
}
