using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class DailyCheckInChatItem
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; }
        public string Day { get; set; }
        public string CoachedOn { get; set; }
        public string CoachingComments { get; set; }
        public bool IsReadOnly { get; set; }
    }
}
