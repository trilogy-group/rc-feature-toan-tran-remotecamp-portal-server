using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace RemoteCamp.Portal.Core.Database.Model
{
    public class UserCheckInChatItem
    {
        public int Id { get; set; }

        /// <summary>
        /// week number start with  1 for first week and so one.
        /// </summary>
        public int WeekNumber { get; set; }

        /// <summary>
        /// This property will hold Day name e.g Monday, Tuesday etc.
        /// </summary>
        [MaxLength(10)]
        public string Day { get; set; }
    }
}
