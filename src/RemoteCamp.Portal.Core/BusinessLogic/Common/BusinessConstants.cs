using System;
using Moq;

namespace RemoteCamp.Portal.Core.BusinessLogic.Common
{
    public static class BusinessConstants
    {
        public static readonly int NumberOfDaysInRemoteCamp = 28;
        public static readonly int NumberOfWorkingDaysInRemoteCamp = 20;
        public static readonly double DailyTarget = 0.75;
        public static readonly string CrossoverJiraServerUrl = "https://crossover.atlassian.net";
        public static readonly double QualityTargetForToday = 1.0;
        public static readonly int CacheExpirationTimeInMinute = 20;
        public static readonly string GradeBookEntityKey = "GradeBookEntity";
        public static readonly string IcGradeBookEntityKey = "IcGradeBookEntity";
        public static readonly string RunCronJobIntervalIn15Minute = "*/15 * * * *";
        public static readonly string RunCronJobIntervalInTuesday9AM = "0 9 * * 2";
        public static readonly string RecurringJobIdGradeBook = "RecurringJobIdGradeBook";
        public static readonly string RecurringJobIdIcGradeBook = "RecurringJobIdIcGradeBook";
        public static readonly string RecurringJobIdWeeklyPlanMissEmail = "RecurringJobIdWeeklyPlanMissEmail";
        public static readonly string CheckInChatProductivity = "productivity";
        public static readonly string CheckInChatQuality = "quality";
        public static readonly int[] QaManualTesterIds = { 9, 20 };
        public static readonly int RemoteCampXoTeamId = 2952;
        public static readonly int WorkWeekCount = 4;
        public static readonly string[] CrnRiqbs =
        {
            "RIQB-177", // CC
            "RIQB-74", // HUT
            "RIQB-281", // TA
            "RIQB-330" // Faster
        };
    }
}
