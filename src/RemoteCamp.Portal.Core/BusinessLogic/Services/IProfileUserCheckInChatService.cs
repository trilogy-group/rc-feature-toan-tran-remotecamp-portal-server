using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using UserCheckInChatItem = RemoteCamp.Portal.Core.BusinessLogic.Data.UserCheckInChatItem;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public interface IProfileUserCheckInChatService : IGenericService<UserCheckInChatItemStatus>
    {
        Task<ServiceValueResponse<IList<List<UserCheckInChatItem>>>> GetAllByEmaildAsync(string email);
        Task<ServiceValueResponse<DailyCheckInChatItem>> GetByEmailAndDayAsync(string email, int day);

        Task<ServiceResponse> UpdateCheckInChatItemStatusAsync(CheckInChat checkInChat);
    }
}
