using Newtonsoft.Json;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Infrastructure.Crossover;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public class ProfileUserComplianceRepository : IProfileUserComplianceRepository
    {
        private readonly ICrossoverClient _crossoverClient;

        public ProfileUserComplianceRepository(ICrossoverClient crossoverClient)
        {
            _crossoverClient = crossoverClient;
        }

        public async Task<List<CrossoverTrackerActivity>> GetTeamComplianceByDayAsync(DateTime day, int teamId)
        {
            _crossoverClient.Initialize();
            var userDetailJson =await  _crossoverClient.GetAsync("identity/users/current/detail", null);
            var crossoverCandidateDetail = JsonConvert.DeserializeObject<CrossoverCandidateDetail>(userDetailJson);

            var activityUrl = $"tracker/activity/groups?date={day.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}&fullTeam=true&groups=groups&managerId={crossoverCandidateDetail.ManagerAvatar.Id}&refresh=false&teamId={teamId}&weekly=false";
            var activityJson = await _crossoverClient.GetAsync(activityUrl, null);
            var crossoverTrackerActivity = JsonConvert.DeserializeObject<List<CrossoverTrackerActivity>>(activityJson);

            return crossoverTrackerActivity;
        }
    }
}
