namespace RemoteCamp.Portal.Core.Database.Model
{
    public class WeeklyPlanDay
    {
        public int Id { get; set; }

        public string Day { get; set; }

        public string Summary { get; set; }

        public double? ScoreTarget { get; set; }

        public int WeeklyPlanWeekId { get; set; }
    }
}
