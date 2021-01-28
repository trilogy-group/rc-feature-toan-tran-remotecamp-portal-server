using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Database;
using RemoteCamp.Portal.Core.Database.Model;
using UserCheckInChatItem = RemoteCamp.Portal.Core.BusinessLogic.Data.UserCheckInChatItem;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public class ProfileUserCheckInChatRepository : GenericRepository<UserCheckInChatItemStatus>, IProfileUserCheckInChatRepository
    {
        public ProfileUserCheckInChatRepository(RemoteCampContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<IList<UserCheckInChatItem>> GetAllByUserIdAndStartDateAsync(int userId, DateTime startDate)
        {
            var userCheckInChatItems = from userCheckInChatItem in DbContext.UserCheckInChatItem
                                       join userCheckInChatItemStatus in DbContext.UserCheckInChatItemStatus
                                           on userCheckInChatItem.Id equals userCheckInChatItemStatus.UserCheckInChatItemId
                                       into result
                                       from records in result.Where(f => f.UserId == userId && f.CreatedDate >= startDate).DefaultIfEmpty()
                                       select new UserCheckInChatItem
                                       {
                                           WeekNumber = userCheckInChatItem.WeekNumber,
                                           Day = userCheckInChatItem.Day,
                                           Id = userCheckInChatItem.Id,
                                           Done = records.IsCompleted
                                       };
            return await userCheckInChatItems.ToListAsync();
        }

        public async Task<DailyCheckInChatItem> GetByUserIdDayAndStartDateAsync(int userId, int day, DateTime startDate)
        {
            var userCheckInChatItems = from userCheckInChatItem in DbContext.UserCheckInChatItem
                                       join userCheckInChatItemStatus in DbContext.UserCheckInChatItemStatus
                                           on userCheckInChatItem.Id equals userCheckInChatItemStatus.UserCheckInChatItemId
                                       into result
                                       from records in result.Where(f => f.UserId == userId && f.CreatedDate >= startDate).DefaultIfEmpty()
                                       where userCheckInChatItem.Id == day
                                       select new DailyCheckInChatItem
                                       {
                                           WeekNumber = userCheckInChatItem.WeekNumber,
                                           Day = userCheckInChatItem.Day,
                                           Id = userCheckInChatItem.Id,
                                           CoachingComments = records.Comment,
                                           CoachedOn = records.Productivity.HasValue && records.Productivity.Value ?
                                           BusinessConstants.CheckInChatProductivity :
                                           BusinessConstants.CheckInChatQuality
                                       };
            return await userCheckInChatItems.FirstOrDefaultAsync();

        }

    }
}
