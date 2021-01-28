using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class ProfileUserCalendar
    {
        public string Header { get; set; }
        public IList<WeekDetail> Week { get; set; } = new List<WeekDetail>();

        public class WeekDetail
        {
            public string Day { get; set; }
            public string Description { get; set; }
            public IList<UserCalendarActionItem> Actions { get; set; } = new List<UserCalendarActionItem>();
        }

        public class UserCalendarActionItem
        {
            public string Description { get; set; }
            public string Url { get; set; }
            public string AdditionalUrl { get; set; }
            public string AdditionalUrlDescription { get; set; }
            public int Duration { get; set; }
            public bool IsCompleted { get; set; }
            public int Position { get; set; }
            public int UserCalendarActionItemId { get; set; }
        }
    }
}
