using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteCamp.Portal.Core.Database.Model
{
    public class UserCalendarItemStatus
    {
        public int Id { get; set; }

        public int UserCalendarItemId { get; set; }

        public bool? IsCompleted { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
