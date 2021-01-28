using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Common;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using UserCheckInChatItem = RemoteCamp.Portal.Core.BusinessLogic.Data.UserCheckInChatItem;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public class ProfileUserCheckInChatService : GenericService<UserCheckInChatItemStatus>, IProfileUserCheckInChatService
    {
        private readonly IProfileUserCheckInChatRepository _profileUserCheckInChatRepository;
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        private readonly ITimeService _timeService;

        public ProfileUserCheckInChatService(IProfileUserCheckInChatRepository profileUserCheckInChatRepository,
            IUserService userService,
            IProfileService profileService,
            ITimeService timeService) : base(profileUserCheckInChatRepository)
        {
            _profileUserCheckInChatRepository = profileUserCheckInChatRepository;
            _userService = userService;
            _profileService = profileService;
            _timeService = timeService;
        }

        public async Task<ServiceValueResponse<IList<List<UserCheckInChatItem>>>> GetAllByEmaildAsync(string email)
        {
            var getUserResponse = await _userService.GetOrCreateByEmailAsync(email);
            if (!getUserResponse.IsSuccess)
            {
                return ServiceValueResponse<IList<List<UserCheckInChatItem>>>.FromErrors(getUserResponse.Errors);
            }

            var profileResponse = await _profileService.GetAsync(email);
            if (!profileResponse.IsSuccess)
            {
                return ServiceValueResponse<IList<List<UserCheckInChatItem>>>.FromErrors(profileResponse.Errors);
            }

            var days = profileResponse.Value.GetNumberOfPassedWorkingDays(_timeService);
            var startDate = profileResponse.Value.StartDate;
            var rcCheckInChatItems = await _profileUserCheckInChatRepository.GetAllByUserIdAndStartDateAsync(getUserResponse.Value.Id, startDate.Value);

            var profileUserCheckInChatItems = rcCheckInChatItems.GroupBy(x => new { x.WeekNumber }).ToList();
            var listUserCheckInChatItem = new List<List<UserCheckInChatItem>>();
            var recordCount = 1;
            foreach (var weeklyCicData in profileUserCheckInChatItems)
            {
                var listWeeklyCic = new List<UserCheckInChatItem>();
                foreach (var weekData in weeklyCicData.OrderBy(x => x.Id))
                {
                    listWeeklyCic.Add(new UserCheckInChatItem
                    {
                        Day = weekData.Day,
                        Done = recordCount <= days && weekData.Done == null ? false : weekData.Done,
                        Id = weekData.Id,
                        WeekNumber = weekData.WeekNumber,
                        IsToday = recordCount == days,
                        IsReadOnly = recordCount < days
                    });
                    recordCount++;
                }
                listUserCheckInChatItem.Add(listWeeklyCic);
            }
            return ServiceValueResponse<IList<List<UserCheckInChatItem>>>.Success(listUserCheckInChatItem);
        }

        public async Task<ServiceValueResponse<DailyCheckInChatItem>> GetByEmailAndDayAsync(string email, int day)
        {
            var getUserResponse = await _userService.GetOrCreateByEmailAsync(email);
            if (!getUserResponse.IsSuccess)
            {
                return ServiceValueResponse<DailyCheckInChatItem>.FromErrors(getUserResponse.Errors);
            }

            var profileResponse = await _profileService.GetAsync(email);
            if (!profileResponse.IsSuccess)
            {
                return ServiceValueResponse<DailyCheckInChatItem>.FromErrors(profileResponse.Errors);
            }
            
            var startDate = profileResponse.Value.StartDate;
            var days = profileResponse.Value.GetNumberOfPassedWorkingDays(_timeService);
            var rcCheckInChatItem = await _profileUserCheckInChatRepository.GetByUserIdDayAndStartDateAsync(getUserResponse.Value.Id, day, startDate.Value);
            rcCheckInChatItem.IsReadOnly = day < days;
            return ServiceValueResponse<DailyCheckInChatItem>.Success(rcCheckInChatItem);
        }

        public async Task<ServiceResponse> UpdateCheckInChatItemStatusAsync(CheckInChat checkInChat)
        {
            var getUserResponse = await _userService.GetOrCreateByEmailAsync(checkInChat.Email);
            if (!getUserResponse.IsSuccess)
            {
                return ServiceResponse.FromErrors(getUserResponse.Errors);
            }
            
            Func<string, bool> isProductivity = coachedOn => coachedOn.Equals(BusinessConstants.CheckInChatProductivity);
            Func<string, bool> IsQuality = coachedOn => coachedOn.Equals(BusinessConstants.CheckInChatQuality);

            var userCheckInChatItemStatus = await EntityRepository
                .Query()
                .Where(x => x.UserCheckInChatItemId == checkInChat.DayId && x.UserId == getUserResponse.Value.Id)
                .FirstOrDefaultAsync();

            if (userCheckInChatItemStatus == null)
            {
                userCheckInChatItemStatus = new UserCheckInChatItemStatus
                {
                    Comment = checkInChat.CoachingComments,
                    IsCompleted = true,
                    CreatedDate = DateTime.UtcNow,
                    Productivity = isProductivity(checkInChat.CoachedOn),
                    Quality = IsQuality(checkInChat.CoachedOn),
                    UserId = getUserResponse.Value.Id,
                    UserCheckInChatItemId = checkInChat.DayId
                };
                await EntityRepository.InsertAsync(userCheckInChatItemStatus);
            }
            else
            {
                userCheckInChatItemStatus.Productivity = isProductivity(checkInChat.CoachedOn);
                userCheckInChatItemStatus.Quality = IsQuality(checkInChat.CoachedOn);
                userCheckInChatItemStatus.UpdatedDate = DateTime.UtcNow;
                userCheckInChatItemStatus.Comment = checkInChat.CoachingComments;
                await EntityRepository.UpdateAsync(userCheckInChatItemStatus);
            }
            return ServiceResponse.Success();
        }
    }
}
