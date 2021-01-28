using System.Linq;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.Database.Model;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public interface IUserCalendarItemRepository
    {
        Task<UserCalendarItem> GetAsync(int id);
        IQueryable<UserCalendarItem> Query();
        Task InsertAsync(UserCalendarItem entity);
        Task UpdateAsync(UserCalendarItem entity);
    }
}