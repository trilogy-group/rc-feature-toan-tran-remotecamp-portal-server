using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Database;
using RemoteCamp.Portal.Core.Database.Model;
using UserCalendarItem = RemoteCamp.Portal.Core.BusinessLogic.Data.UserCalendarItem;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public class ProfileUserCalendarItemStatusRepository : GenericRepository<UserCalendarItemStatus>, IProfileUserCalendarItemStatusRepository
    {
        public ProfileUserCalendarItemStatusRepository(RemoteCampContext dbContext)
        {
            DbContext = dbContext;
        }
        
        public async Task<IList<UserCalendarItem>> GetAllAsync(int userId, CalendarType calendarType)
        {
            var userCalendarItems = from userCalendarItem in DbContext.UserCalendarItems
                                    join userCalendarItemAction in DbContext.UserCalendarItemActions
                                        on userCalendarItem.Id equals userCalendarItemAction.UserCalendarItemId
                                    join userCalendarItemStatus in DbContext.UserCalendarItemStatus
                                        on userCalendarItemAction.Id equals userCalendarItemStatus.UserCalendarItemId
                                    into result
                                    from records in result.Where(f => f.UserId == userId).DefaultIfEmpty()
                                    where userCalendarItemAction.Id == records.UserCalendarItemId && records.IsCompleted.HasValue && records.IsCompleted.Value 
                                          || userCalendarItem.CalendarType == calendarType && userCalendarItemAction.IsDeleted.HasValue && !userCalendarItemAction.IsDeleted.Value
                                    orderby userCalendarItem.WeekNumber  ascending
                                    select new UserCalendarItem
                                    {
                                        Id = userCalendarItem.Id,
                                        CalendarType = userCalendarItem.CalendarType,
                                        WeekNumber = userCalendarItem.WeekNumber,
                                        ItemDescription = userCalendarItem.Description,
                                        Day = userCalendarItem.Day,
                                        ActionDescription = userCalendarItemAction.Description,
                                        Duration = userCalendarItemAction.Duration,
                                        ActionUrl = userCalendarItemAction.Url,
                                        Position = userCalendarItemAction.Position,
                                        AdditionalActionUrl = userCalendarItemAction.AdditionalUrl,
                                        IsCompleted = records.IsCompleted ?? false,
                                        IsDeleted = userCalendarItemAction.IsDeleted ?? false,
                                        UserCalendarActionItemId = userCalendarItemAction.Id,
                                        Header = userCalendarItem.Header
                                    };
            return await userCalendarItems.ToListAsync();
        }

        public async Task<IList<UserCalendarItem>> GetAllMissedCalendarItemByUserIdAndDayAsync(int userId, CalendarType calendarType, int day)
        {
            var userCalendarItems = from userCalendarItem in DbContext.UserCalendarItems
                                    join userCalendarItemAction in DbContext.UserCalendarItemActions
                                        on userCalendarItem.Id equals userCalendarItemAction.UserCalendarItemId
                                    join userCalendarItemStatus in DbContext.UserCalendarItemStatus
                                        on userCalendarItemAction.Id equals userCalendarItemStatus.UserCalendarItemId
                                    into result
                                    from records in result.Where(f => f.UserId == userId).DefaultIfEmpty()
                                    where 
                                        (
                                            userCalendarItem.WeekNumber == 0
                                            || userCalendarItem.Day == "Monday" && 1 + (userCalendarItem.WeekNumber - 1) * 5 < day
                                            || userCalendarItem.Day == "Tuesday" && 2 + (userCalendarItem.WeekNumber - 1) * 5 < day
                                            || userCalendarItem.Day == "Wednesday" && 3 + (userCalendarItem.WeekNumber - 1) * 5 < day
                                            || userCalendarItem.Day == "Thursday" && 4 + (userCalendarItem.WeekNumber - 1) * 5 < day
                                            || userCalendarItem.Day == "Friday" && 5 + (userCalendarItem.WeekNumber - 1) * 5 < day
                                        )
                                        && userCalendarItem.CalendarType == calendarType
                                    && (userCalendarItemAction.IsDeleted == null ||
                                        (userCalendarItemAction.IsDeleted.HasValue
                                    && !userCalendarItemAction.IsDeleted.Value))
                                    && (records.IsCompleted == null || (records.IsCompleted.HasValue && !records.IsCompleted.Value))
                                    select new UserCalendarItem
                                    {
                                        Id = userCalendarItem.Id,
                                        CalendarType = userCalendarItem.CalendarType,
                                        WeekNumber = userCalendarItem.WeekNumber,
                                        ItemDescription = userCalendarItem.Description,
                                        Day = userCalendarItem.Day,
                                        ActionDescription = userCalendarItemAction.Description,
                                        Duration = userCalendarItemAction.Duration,
                                        ActionUrl = userCalendarItemAction.Url,
                                        Position = userCalendarItemAction.Position,
                                        AdditionalActionUrl = userCalendarItemAction.AdditionalUrl,
                                        IsCompleted = records.IsCompleted ?? false,
                                        IsDeleted = userCalendarItemAction.IsDeleted ?? false,
                                        UserCalendarActionItemId = userCalendarItemAction.Id,
                                        Header = userCalendarItem.Header
                                    };
            return await userCalendarItems.ToListAsync();
        }

    }
}
