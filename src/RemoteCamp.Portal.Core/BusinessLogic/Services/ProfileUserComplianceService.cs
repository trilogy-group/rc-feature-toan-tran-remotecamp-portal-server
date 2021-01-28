using System;
using System.Linq;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public class ProfileUserComplianceService : IProfileUserComplianceService
    {
        private readonly IProfileUserComplianceRepository _profileUserComplianceRepository;
        private readonly IErTicketRepository _erTicketRepository;

        public ProfileUserComplianceService(IProfileUserComplianceRepository profileUserComplianceRepository,
            IErTicketRepository erTicketRepository)
        {
            _profileUserComplianceRepository = profileUserComplianceRepository;
            _erTicketRepository = erTicketRepository;
        }

        public async Task<ServiceValueResponse<ProfileCompliance>> GetComplianceByEmailAsync(string email)
        {
            var profile = await _erTicketRepository.GetByCompanyEmailAsync(email);
            if (profile == null)
            {
                return ServiceValueResponse<ProfileCompliance>.Error(ErrorCodes.NotFound, "User dose not exists in ER jira project.");
            }

            var currentDate = DateTime.UtcNow.Date;

            var startDate = profile.StartDate.Value.Date;
            var endDate = startDate.AddDays(BusinessConstants.NumberOfDaysInRemoteCamp);

            var days = Math.Min(profile.GetNumberOfPassedWorkingDays(), BusinessConstants.NumberOfWorkingDaysInRemoteCamp);

            var date = days < BusinessConstants.NumberOfWorkingDaysInRemoteCamp ? currentDate.GetPreviousWorkingDay() : endDate.GetPreviousWorkingDay();

            var result = await _profileUserComplianceRepository.GetTeamComplianceByDayAsync(date, BusinessConstants.RemoteCampXoTeamId);
            var profileCompliance = new ProfileCompliance();
            if (result != null)
            {
                var record = result.FirstOrDefault(x => x.Assignment.Candidate.Email.Equals(profile.XoLoginEmail) || x.Assignment.Candidate.Email.Equals(email));
                if (record != null)
                {
                    profileCompliance.Focus = record.Grouping.FocusScore;
                    profileCompliance.Intensity = record.Grouping.IntensityScore;
                    profileCompliance.Alignment = record.Grouping.AlignmentScore;
                }
            }
            return ServiceValueResponse<ProfileCompliance>.Success(profileCompliance);
        }
    }
}
