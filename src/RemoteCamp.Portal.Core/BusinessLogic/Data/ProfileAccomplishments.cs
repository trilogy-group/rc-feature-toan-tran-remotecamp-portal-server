using System.Collections.Generic;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class ProfileAccomplishments
    {
        public IList<DailyData> Daily { get; set; } = new List<DailyData>();
        public IList<WeeklyData> Weekly { get; set; } = new List<WeeklyData>();
        public QualitySummaryData QualitySummary { get; set; } = new QualitySummaryData();
        public QualitySummaryData GraduationQualitySummary { get; set; } = new QualitySummaryData();
        public ScoreSummaryData ScoreSummary { get; set; } = new ScoreSummaryData();
        public IList<ModuleData> ModuleDistribution { get; set; } = new List<ModuleData>();

        public class DailyData
        {
            public double Productivity { get; set; }
            public double? Quality { get; set; }
            public double? PlannedProductivity { get; set; }
        }

        public class WeeklyData
        {
            public double Productivity { get; set; }
            public double? Quality { get; set; }
        }

        public class QualitySummaryData
        {
            public double? Approved { get; set; }
            public double? TargetForToday { get; set; }
        }

        public class ScoreSummaryData
        {
            public double Approved { get; set; }
            public double InReview { get; set; }
            public double InProgress { get; set; }
            public double TargetForToday { get; set; }
        }

        public class ModuleData
        {
            public string Module { get; set; }
            public double? ModuleTotalAverageFtar { get; set; }
            public IList<double?> QualityDistribution { get; set; } = new List<double?>();
            public IList<double?> ScoreDistribution { get; set; } = new List<double?>();
        }
    }
}
