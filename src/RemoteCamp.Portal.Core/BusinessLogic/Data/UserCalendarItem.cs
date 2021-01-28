using System;
using System.Collections.Generic;
using System.Text;
using RemoteCamp.Portal.Core.Database.Model;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class UserCalendarItem
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; }
        public string Day { get; set; }
        public string Header { get; set; }
        public string ItemDescription { get; set; }
        public string ActionDescription { get; set; }
        public string ActionUrl { get; set; }
        public string AdditionalActionUrl { get; set; }
        public int Duration { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
        public int Position { get; set; }
        public CalendarType CalendarType { get; set; }
        public int UserCalendarActionItemId { get; set; }

    }
}
