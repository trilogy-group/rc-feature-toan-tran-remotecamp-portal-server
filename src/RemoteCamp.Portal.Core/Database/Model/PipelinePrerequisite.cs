using System.ComponentModel.DataAnnotations;

namespace RemoteCamp.Portal.Core.Database.Model
{
    public class PipelinePrerequisite
    {
        [Key]
        public int Id { get; set; }

        public int PipelineId { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }
    }
}
