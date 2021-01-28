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
using static RemoteCamp.Portal.Core.BusinessLogic.Data.ProfileUserCalendar;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public class ProfileUserCalendarService : GenericService<UserCalendarItemStatus>, IProfileUserCalendarService
    {
        private readonly IProfileUserCalendarItemStatusRepository _profileUserCalendarItemStatusRepository;
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        private readonly ITemplater _templater;
        private readonly ITimeService _timeService;

        public ProfileUserCalendarService(IProfileUserCalendarItemStatusRepository profileUserCalendarItemStatusRepository,
            IUserService userService,
            IProfileService profileService,
            ITemplater templater,
            ITimeService timeService) : base(profileUserCalendarItemStatusRepository)
        {
            _profileUserCalendarItemStatusRepository = profileUserCalendarItemStatusRepository;
            _userService = userService;
            _profileService = profileService;
            _templater = templater;
            _timeService = timeService;
        }

        public async Task<ServiceValueResponse<IList<ProfileUserCalendar>>> GetAllAsync(string email)
        {
            var getProfileResponse = await _profileService.GetAsync(email);
            if (!getProfileResponse.IsSuccess)
            {
                return ServiceValueResponse<IList<ProfileUserCalendar>>.FromErrors(getProfileResponse.Errors);
            }

            var profile = getProfileResponse.Value;
            
            var getUserResponse = await _userService.GetOrCreateByEmailAsync(email);
            if (!getUserResponse.IsSuccess)
            {
                return ServiceValueResponse<IList<ProfileUserCalendar>>.FromErrors(getUserResponse.Errors);
            }

            var requiredCalendarType = profile.IcRemoteUEnabled ? CalendarType.ICRemoteU : CalendarType.EngRemoteU;
            var rcCalendarItems = await _profileUserCalendarItemStatusRepository.GetAllAsync(getUserResponse.Value.Id, requiredCalendarType);
            
            var profileUserCalendarItems = rcCalendarItems
                .OrderBy(x => x.WeekNumber).ThenBy(x => x.GetDayIndex())
                .GroupBy(x => new { x.WeekNumber }).ToList();

            var listProfileUserCalendarItems = new List<ProfileUserCalendar>();
            foreach (var calendarItems in profileUserCalendarItems)
            {
                var weekDays = calendarItems.GroupBy(x => x.Day);
                var profileUserCalendar = new ProfileUserCalendar();
                foreach (var weekData in weekDays)
                {
                    var weekDetail = new WeekDetail();
                    foreach (var item in weekData)
                    {
                        if (string.IsNullOrWhiteSpace(weekDetail.Day))
                        {
                            weekDetail.Day = item.Day;
                            weekDetail.Description = item.ItemDescription.ReplaceSingleQuoteToDoubleQuote().Trim();
                            profileUserCalendar.Header = item.Header;
                        }

                        var urlDescription = item.ActionDescription.ReplaceSingleQuoteToDoubleQuote().Trim();
                        var additionalUrlDescription = string.Empty;
                        if (!string.IsNullOrWhiteSpace(item.AdditionalActionUrl))
                        {
                            var desriptionArray = urlDescription.Split(' ');
                            urlDescription = desriptionArray.First();
                            additionalUrlDescription = string.Join(" ", desriptionArray, 1, desriptionArray.Length - 1);
                        }

                        weekDetail.Actions.Add(new UserCalendarActionItem
                        {
                            Description = urlDescription,
                            Duration = item.Duration,
                            IsCompleted = item.IsCompleted,
                            Url = _templater.Render(item.ActionUrl, profile),
                            AdditionalUrl = _templater.Render(item.AdditionalActionUrl, profile),
                            AdditionalUrlDescription = additionalUrlDescription,
                            UserCalendarActionItemId = item.UserCalendarActionItemId,
                            Position = item.Position
                        });
                    }

                    profileUserCalendar.Week.Add(weekDetail);
                }

                listProfileUserCalendarItems.Add(profileUserCalendar);
            }

            return ServiceValueResponse<IList<ProfileUserCalendar>>.Success(listProfileUserCalendarItems);
        }

        public async Task<ServiceValueResponse<IList<MissedCalendarItem>>> GetAllMissedCalendarItemByEmailAsync(string email)
        {
            var getProfileResponse = await _profileService.GetAsync(email);
            if (!getProfileResponse.IsSuccess)
            {
                return ServiceValueResponse<IList<MissedCalendarItem>>.FromErrors(getProfileResponse.Errors);
            }

            var profile = getProfileResponse.Value;

            var getUserResponse = await _userService.GetOrCreateByEmailAsync(email);
            if (!getUserResponse.IsSuccess)
            {
                return ServiceValueResponse<IList<MissedCalendarItem>>.FromErrors(getUserResponse.Errors);
            }

            var days = Math.Min(profile.GetNumberOfPassedWorkingDays(_timeService), BusinessConstants.NumberOfWorkingDaysInRemoteCamp);

            var requiredCalendarType = profile.IcRemoteUEnabled ? CalendarType.ICRemoteU : CalendarType.EngRemoteU;
            var rcCalendarItems = await _profileUserCalendarItemStatusRepository.GetAllMissedCalendarItemByUserIdAndDayAsync(getUserResponse.Value.Id, requiredCalendarType, days + 1);

            var profileUserCalendarItems = rcCalendarItems.GroupBy(x => new { x.WeekNumber });

            var listMissedCalendarItems = new List<MissedCalendarItem>();
            foreach (var calendarItems in profileUserCalendarItems)
            {
                var weekDays = calendarItems.GroupBy(x => x.Day);

                foreach (var weekData in weekDays)
                {
                    foreach (var item in weekData)
                    {
                        listMissedCalendarItems.Add(new MissedCalendarItem
                        {
                            Day = item.Day,
                            Name = item.ActionDescription,
                            Week = item.WeekNumber,
                            ActionUrl1 = _templater.Render(item.ActionUrl, profile),
                            ActionUrl2 = _templater.Render(item.AdditionalActionUrl, profile),
                            DayNumberInRemoteU = item.GetRemoteUDayIndex() + 1
                        });
                    }
                }
            }
            return ServiceValueResponse<IList<MissedCalendarItem>>.Success(listMissedCalendarItems);
        }

        public async Task<ServiceResponse> UpdateItemStatusAsync(string email, int id, bool isCompleted)
        {
            var getUserResponse = await _userService.GetOrCreateByEmailAsync(email);
            if (!getUserResponse.IsSuccess)
            {
                return ServiceResponse.FromErrors(getUserResponse.Errors);
            }

            var userCalendarItemStatus = await EntityRepository
                .Query()
                .Where(x => x.UserCalendarItemId == id && x.UserId == getUserResponse.Value.Id)
                .FirstOrDefaultAsync();
            if (userCalendarItemStatus == null)
            {
                userCalendarItemStatus = new UserCalendarItemStatus
                {
                    IsCompleted = isCompleted,
                    UserCalendarItemId = id,
                    UserId = getUserResponse.Value.Id
                };
                await EntityRepository.InsertAsync(userCalendarItemStatus);
            }
            else
            {
                userCalendarItemStatus.IsCompleted = isCompleted;
                await EntityRepository.UpdateAsync(userCalendarItemStatus);
            }
            return ServiceResponse.Success();
        }

    }
}
