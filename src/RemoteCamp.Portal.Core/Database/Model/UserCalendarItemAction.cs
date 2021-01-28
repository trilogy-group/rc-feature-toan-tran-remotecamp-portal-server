using System.ComponentModel.DataAnnotations;

namespace RemoteCamp.Portal.Core.Database.Model
{
    public class UserCalendarItemAction : ILogicalDeleteEntity
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(2083)]
        public string Url { get; set; }

        [MaxLength(2083)]
        public string AdditionalUrl { get; set; }

        public int Duration { get; set; }

        public bool? IsDeleted { get; set; }
        
        public int Position { get; set; }

        public int UserCalendarItemId { get; set; }
        public UserCalendarItem UserCalendarItem { get; set; }
    }
}
