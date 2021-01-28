using System;
using System.ComponentModel.DataAnnotations;

namespace RemoteCamp.Portal.Core.Database.Model
{
    public class ApiKey
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Key { get; set; }

        public bool IsActive { get; set; }
    }
}
