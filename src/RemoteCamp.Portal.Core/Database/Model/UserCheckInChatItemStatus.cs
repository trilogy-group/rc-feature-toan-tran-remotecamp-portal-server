using System;
using System.ComponentModel.DataAnnotations;

namespace RemoteCamp.Portal.Core.Database.Model
{
    public class UserCheckInChatItemStatus
    {
        public int Id { get; set; }

        public bool? Productivity { get; set; }

        public bool? Quality { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; }

        public int UserCheckInChatItemId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? IsCompleted { get; set; }

        public UserCheckInChatItem UserCheckInChatItem { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
