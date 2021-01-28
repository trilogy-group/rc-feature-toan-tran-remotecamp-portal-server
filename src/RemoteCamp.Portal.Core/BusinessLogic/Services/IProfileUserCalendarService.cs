using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public interface IProfileUserCalendarService : IGenericService<UserCalendarItemStatus>
    {
        /// <summary>
        /// Get 4 week user calendar Items.
        /// </summary>
        /// <param name="email">company email address of a remote camp participant.</param>
        /// <returns></returns>
        Task<ServiceValueResponse<IList<ProfileUserCalendar>>> GetAllAsync(string email);

        /// <summary>
        /// Update User Calendar Item Status.
        /// </summary>
        /// <param name="email">company email address of a remote camp participant.</param>
        /// <param name="id">id of UserCalendarItemStatus table</param>
        /// <param name="isCompleted">completed status.</param>
        /// <returns></returns>
        Task<ServiceResponse> UpdateItemStatusAsync(string email, int id, bool isCompleted);

        Task<ServiceValueResponse<IList<MissedCalendarItem>>> GetAllMissedCalendarItemByEmailAsync(string email);
    }
}
