using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class UserCheckInChatItem
    {
        public int Id { get; set; }

        public int WeekNumber { get; set; }

        public string Day { get; set; }

        public bool? Done { get; set; }

        public bool IsToday { get; set; }

        public bool IsReadOnly { get; set; }
    }
}
