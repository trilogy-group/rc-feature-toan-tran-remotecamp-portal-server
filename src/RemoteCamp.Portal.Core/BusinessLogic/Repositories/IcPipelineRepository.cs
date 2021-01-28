using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Database;
using RemoteCamp.Portal.Core.Database.Model;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    class IcPipelineRepository : GenericRepository<Pipeline>, IIcPipelineRepository
    {
        public IcPipelineRepository(RemoteCampContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IList<IcPipeline>> GetAllAsync()
        {
            var pipelines = await DbContext.Pipelines.Include(x => x.Prerequisites).ToListAsync();
            return pipelines.Select(ConvertToIcPipeline).ToList();
        }

        public new async Task<IcPipeline> GetAsync(int id)
        {
            var pipeline = await base.GetAsync(id);
            return ConvertToIcPipeline(pipeline);
        }

        private static IcPipeline ConvertToIcPipeline(Pipeline pipeline)
        {
            if (pipeline == null)
            {
                return null;
            }

            return new IcPipeline
            {
                Id = pipeline.Id,
                Name = pipeline.Name,
                Prerequisites = pipeline.Prerequisites?.Select(
                        y => new IcPipeline.Prerequisite
                        {
                            Name = y.Name,
                            Id = y.Id
                        })
                    .ToList()
            };
        }
    }
}
