using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public class UserCalendarDayService : IUserCalendarDayService
    {
        private readonly IProfileService _profileService;
        private readonly IUserCalendarItemRepository _userCalendarItemRepository;

        public UserCalendarDayService(
            IProfileService profileService,
            IUserCalendarItemRepository userCalendarItemRepository)
        {
            _profileService = profileService;
            _userCalendarItemRepository = userCalendarItemRepository;
        }
        
        public async Task<ServiceValueResponse<UserCalendarDay>> GetByDateAsync(string email, DateTime date)
        {
            var profileResponse = await _profileService.GetAsync(email);
            if (!profileResponse.IsSuccess)
            {
                return ServiceValueResponse<UserCalendarDay>.FromErrors(profileResponse.Errors);
            }

            var profile = profileResponse.Value;
            
            var calendarType = profile.IcRemoteUEnabled ? CalendarType.ICRemoteU : CalendarType.EngRemoteU;
            var weekNumber = profile.GetWeekIndex(date) + 1;
            var dayOfWeek = date.DayOfWeek.ToString();

            var userCalendarItem = await _userCalendarItemRepository.Query()
                .FirstOrDefaultAsync(x => x.CalendarType == calendarType
                                     && x.WeekNumber == weekNumber
                                     && x.Day == dayOfWeek);

            var details = userCalendarItem == null
                ? null
                : new UserCalendarDay.DayDetails
                {
                    Header = userCalendarItem.Header,
                    Description = userCalendarItem.Description
                };
            
            return ServiceValueResponse<UserCalendarDay>.Success(new UserCalendarDay
            {
                DayOfWeek = dayOfWeek,
                WeekNumber = weekNumber,
                DayNumber = profile.GetDayIndex(date) + 1,
                Details = details
            });
        }        
    }
}