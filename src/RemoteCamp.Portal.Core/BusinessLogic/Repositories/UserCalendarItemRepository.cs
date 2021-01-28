using RemoteCamp.Portal.Core.Database;
using RemoteCamp.Portal.Core.Database.Model;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public class UserCalendarItemRepository : GenericRepository<UserCalendarItem>, IUserCalendarItemRepository
    {
        public UserCalendarItemRepository(RemoteCampContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}