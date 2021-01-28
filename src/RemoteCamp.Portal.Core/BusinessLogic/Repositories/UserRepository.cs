using RemoteCamp.Portal.Core.Database;
using RemoteCamp.Portal.Core.Database.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(RemoteCampContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
