using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public class ProfileHardestProblemByDayService : IProfileHardestProblemByDayService
    {
        private readonly IProfileService _profileService;
        private readonly IHardestProblemService _hardestProblemService;
        private readonly IRcTaskLoader _rcTaskLoader;

        public ProfileHardestProblemByDayService(IProfileService profileService,
            IHardestProblemService hardestProblemService,
            IRcTaskLoader rcTaskLoader)
        {
            _profileService = profileService;
            _hardestProblemService = hardestProblemService;
            _rcTaskLoader = rcTaskLoader;
        }

        public async Task<ServiceValueResponse<IList<ProfileHardestProblemByDay>>> GetAllAsync(string email)
        {
            var profileResponse = await _profileService.GetAsync(email);

            if (!profileResponse.IsSuccess)
            {
                return ServiceValueResponse<IList<ProfileHardestProblemByDay>>.NotFound($"User with email {email} was not found");
            }
            var profile = profileResponse.Value;

            var rcTasks = await _rcTaskLoader.LoadAsync(profile);
            var hardestProblemsByDay = _hardestProblemService.GetHardestProblemsByDay(rcTasks, profile);
            
            return ServiceValueResponse<IList<ProfileHardestProblemByDay>>.Success(hardestProblemsByDay);
        }
    }
}
