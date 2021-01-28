using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.Database;
using RemoteCamp.Portal.Core.Database.Model;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public class WeeklyPlanWeekRepository : GenericRepository<WeeklyPlanWeek>, IWeeklyPlanWeekRepository
    {
        public WeeklyPlanWeekRepository(RemoteCampContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IList<WeeklyPlanWeek>> GetAllAsync(int userId)
        {
            var userWeeklyPlanItems = from userWeeklyPlanItem in DbContext.WeeklyPlanWeeks.
                                        Where(f => f.UserId == userId).
                                        OrderBy(x => x.WeekNumber).
                                        Include(nameof(WeeklyPlanWeek.Week))
                                        select userWeeklyPlanItem;

            return await userWeeklyPlanItems.ToListAsync();
        }

        public async Task<WeeklyPlanWeek> GetWeeklyPlanForUserAndWeekAsync(int userId, StudyWeek weekNumber)
        {
            var weeklyPlan = await DbContext.WeeklyPlanWeeks.Where(f => f.UserId == userId
                && f.WeekNumber == weekNumber).FirstOrDefaultAsync();

            return weeklyPlan;
        }
    }
}
