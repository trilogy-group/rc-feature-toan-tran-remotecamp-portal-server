using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Database.Model;
using UserCheckInChatItem = RemoteCamp.Portal.Core.BusinessLogic.Data.UserCheckInChatItem;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public interface IProfileUserCheckInChatRepository : IGenericRepository<UserCheckInChatItemStatus>
    {
        Task<IList<UserCheckInChatItem>> GetAllByUserIdAndStartDateAsync(int userId, DateTime startDate);

        Task<DailyCheckInChatItem> GetByUserIdDayAndStartDateAsync(int userId, int day, DateTime startDate);
    }
}
