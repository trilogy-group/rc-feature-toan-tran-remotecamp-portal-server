using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Database.Model;
using UserCalendarItem = RemoteCamp.Portal.Core.BusinessLogic.Data.UserCalendarItem;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public interface IProfileUserCalendarItemStatusRepository : IGenericRepository<UserCalendarItemStatus>
    {
        Task<IList<UserCalendarItem>> GetAllAsync(int userId, CalendarType calendarType);
        Task<IList<UserCalendarItem>> GetAllMissedCalendarItemByUserIdAndDayAsync(int userId, CalendarType calendarType, int day);
    }
}
