using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace RemoteCamp.Portal.Core.Database.Model
{
    public class UserCalendarItem
    {
        public int Id { get; set; }

        // week number start with 0 for Friday  then 1 for first week and so one.
        public int WeekNumber { get; set; }

        // This property will hold Day name e.g Monday, Tuesday etc.
        [MaxLength(10)]
        public string Day { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Header { get; set; }

        public CalendarType CalendarType{ get; set; }

        [NotMapped]
        public ICollection<UserCalendarItemAction> UserCalendarItemActions { get; set; }
    }   
}
