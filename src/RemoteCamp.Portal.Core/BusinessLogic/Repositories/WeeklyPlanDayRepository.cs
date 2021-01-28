using RemoteCamp.Portal.Core.Database;
using RemoteCamp.Portal.Core.Database.Model;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public class WeeklyPlanDayRepository : GenericRepository<WeeklyPlanDay>, IWeeklyPlanDayRepository
    {
        public WeeklyPlanDayRepository(RemoteCampContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
