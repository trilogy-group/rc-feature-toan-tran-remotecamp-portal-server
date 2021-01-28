
using System;
using System.Collections.Generic;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class IcGradeBook
    {
        public string IcName { get; set; }
        public string IcNameShort { get; set; }
        public string Email { get; set; }
        public Quality QualitySummary { get; set; } = new Quality();
        public Score ScoreSummary { get; set; } = new Score();
    }

    public class CachedIcGradeBook
    {
        public DateTime CurrentDateTimeStamp { get; set; }
        public IList<IcGradeBook>  GradeBook { get; set; } = new List<IcGradeBook>();
    }
}
