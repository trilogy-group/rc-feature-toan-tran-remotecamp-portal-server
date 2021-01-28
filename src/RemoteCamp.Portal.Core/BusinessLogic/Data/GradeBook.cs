
using System;
using System.Collections.Generic;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class GradeBook
    {
        public string IcName { get; set; }
        public string IcNameShort { get; set; }
        public string Email { get; set; }
        public string Pipeline { get; set; }
        public string Manager { get; set; }
        public DateTime? Start { get; set; }
        public int? RcXoId { get; set; }
        public Quality QualitySummary { get; set; } = new Quality();
        public Score ScoreSummary { get; set; } = new Score();
    }

    public class CachedGradeBook
    {
        public DateTime CurrentDateTimeStamp { get; set; }
        public IList<GradeBook> GradeBook { get; set; } = new List<GradeBook>();
    }
}
