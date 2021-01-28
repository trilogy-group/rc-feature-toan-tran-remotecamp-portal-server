using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.Database.Model;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public interface IWeeklyPlanWeekRepository : IGenericRepository<WeeklyPlanWeek>
    {
        Task<IList<WeeklyPlanWeek>> GetAllAsync(int userId);
        Task<WeeklyPlanWeek> GetWeeklyPlanForUserAndWeekAsync(int userId, StudyWeek weekNumber);
    }
}
