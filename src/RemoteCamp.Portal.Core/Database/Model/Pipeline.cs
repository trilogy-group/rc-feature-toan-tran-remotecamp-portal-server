using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RemoteCamp.Portal.Core.Database.Model
{
    public class Pipeline
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public IList<PipelinePrerequisite> Prerequisites { get; set; }
    }
}
