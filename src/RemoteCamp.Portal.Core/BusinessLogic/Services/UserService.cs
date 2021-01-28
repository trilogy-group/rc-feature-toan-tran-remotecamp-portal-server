using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Common;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly ITimeService _timeService;

        public UserService(IUserRepository userRepository, ITimeService timeService) : base(userRepository)
        {
            _timeService = timeService ?? throw new ArgumentNullException(nameof(timeService));
        }

        public async Task<ServiceValueResponse<User>> GetOrCreateByEmailAsync(string email)
        {
            var user = await GetByEmailAsync(email); 
            if (user == null)
            {
                try
                {
                    user = await CreateAsync(email);
                }
                catch (DbUpdateException)
                {
                    user = await GetByEmailAsync(email);
                }
            }
            
            return new ServiceValueResponse<User>
            {
                Value = user
            };
        }

        private async Task<User> GetByEmailAsync(string email)
        {
            return await EntityRepository
                .Query()
                .Where(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefaultAsync();
        }
        
        private async Task<User> CreateAsync(string email)
        {
            var user = new User
            {
                Email = email,
                CreatedAt = _timeService.UtcNow
            };
            await EntityRepository.InsertAsync(user);
            return user;
        }
    }
}
