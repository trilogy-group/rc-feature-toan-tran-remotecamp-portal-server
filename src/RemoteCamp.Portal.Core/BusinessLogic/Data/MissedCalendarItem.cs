using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class MissedCalendarItem
    {
        public int Week { get; set; }
        public string Day { get; set; }
        public string Name { get; set; }
        public int DayNumberInRemoteU { get; set; }
        public string ActionUrl1 { get; set; }
        public string ActionUrl2 { get; set; }
    }
}
