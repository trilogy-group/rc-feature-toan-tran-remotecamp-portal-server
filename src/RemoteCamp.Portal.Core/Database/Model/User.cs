using System;
using System.ComponentModel.DataAnnotations;

namespace RemoteCamp.Portal.Core.Database.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(320)]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
