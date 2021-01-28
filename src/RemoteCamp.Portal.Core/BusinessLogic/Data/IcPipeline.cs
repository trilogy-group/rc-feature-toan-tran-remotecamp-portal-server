using System.Collections.Generic;

namespace RemoteCamp.Portal.Core.BusinessLogic.Data
{
    public class IcPipeline
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Prerequisite> Prerequisites { get; set; } = new List<Prerequisite>();

        public class Prerequisite
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
