namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class UserCalendarDay
    {
        public string DayOfWeek { get; set; }
        public int DayNumber { get; set; }
        public int WeekNumber { get; set; }
        public DayDetails Details { get; set; }

        public class DayDetails
        {
            public string Header { get; set; }
            public string Description { get; set; }
        }
    }
}