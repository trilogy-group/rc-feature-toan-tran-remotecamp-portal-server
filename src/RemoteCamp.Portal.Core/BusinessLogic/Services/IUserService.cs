using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public interface IUserService : IGenericService<User>
    {
        Task<ServiceValueResponse<User>> GetOrCreateByEmailAsync(string email);
    }
}
