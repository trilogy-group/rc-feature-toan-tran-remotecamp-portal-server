using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Database.Extensions;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public class WeeklyPlanService : GenericService<WeeklyPlanWeek>, IWeeklyPlanService
    {
        private readonly IWeeklyPlanWeekRepository _weekRepository;
        private readonly IWeeklyPlanDayRepository _dayRepository;
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        private readonly IErTicketRepository _erTicketRepository;

        public WeeklyPlanService(
            IErTicketRepository erTicketRepository,
            IWeeklyPlanWeekRepository weekRepository, 
            IWeeklyPlanDayRepository dayRepository,
            IUserService userService,
            IProfileService profileService) 
            : base(weekRepository)
        {
            _weekRepository = weekRepository ?? throw new ArgumentNullException(nameof(weekRepository));
            _dayRepository = dayRepository ?? throw new ArgumentNullException(nameof(dayRepository));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
            _erTicketRepository = erTicketRepository ?? throw new ArgumentNullException(nameof(erTicketRepository));
        }

        public async Task<ServiceValueResponse<IList<WeeklyPlanWeek>>> GetAllAsync(string email)
        {
            var getUserResponse = await _userService.GetOrCreateByEmailAsync(email);
            if (!getUserResponse.IsSuccess)
            {
                return ServiceValueResponse<IList<WeeklyPlanWeek>>.FromErrors(getUserResponse.Errors);
            }

            return await GetAllWeeklyPlanForRcAsync(getUserResponse);
        }

        public async Task<ServiceResponse> SubmitPlansAsync(string email, IList<WeeklyPlanWeek> plans, DayOfWeek deadLine)
        {
            var getUserTask = _userService.GetOrCreateByEmailAsync(email);
            var getProfileTask = _profileService.GetAsync(email);

            var userResponse = await getUserTask;
            if (!userResponse.IsSuccess)
            {
                return ServiceResponse.FromErrors(userResponse.Errors);
            }

            var profileResponse = await getProfileTask;
            if (!profileResponse.IsSuccess)
            {
                return ServiceResponse.FromErrors(profileResponse.Errors);
            }

            return await SavePlans(userResponse.Value, profileResponse.Value, plans, deadLine);
        }

        public async Task<ServiceResponse> ChangeWeelyPlanApprovalAsync(string email, bool isApproved, StudyWeek weekNumber)
        {
            var deadLine = DayOfWeek.Tuesday;
            var getProfileTask = _profileService.GetAsync(email);
            var getUserTask = _userService.GetOrCreateByEmailAsync(email);
            var userResponse = await getUserTask;
            if (!userResponse.IsSuccess)
            {
                return ServiceResponse.FromErrors(userResponse.Errors);
            }

            var profileResponse = await getProfileTask;
            if (!profileResponse.IsSuccess)
            {
                return ServiceResponse.FromErrors(profileResponse.Errors);
            }

            var profile = profileResponse.Value;

            var weeklyPlanItem = await EntityRepository
                        .Query()
                        .Where(x => x.WeekNumber == weekNumber && x.UserId == userResponse.Value.Id)
                        .FirstOrDefaultAsync();

            if (weeklyPlanItem != null)
            {
                if (weeklyPlanItem.Submitted)
                {
                    if (weeklyPlanItem.CanApprove(profile.StartDate.Value, deadLine))
                    {
                        weeklyPlanItem.Approved = isApproved;
                        await EntityRepository.UpdateAsync(weeklyPlanItem);
                        return ServiceResponse.Success();
                    }
                    
                    return ServiceResponse.Error(ErrorCodes.InvalidOperation, $"Plan can only be approved in {deadLine} for current week.");
                }
                
                return ServiceResponse.Error(ErrorCodes.InvalidOperation, "Plan was not submitted.");
            }
            
            return ServiceResponse.Error(ErrorCodes.InvalidOperation, "No such plan found.");
        }

        /// <summary>
        /// Returns plan for the last work day of student
        /// </summary>
        /// <param name="email">Email address of student</param>
        /// <param name="day">Day number of student, between 1 to 20</param>
        /// <returns></returns>
        public async Task<ServiceValueResponse<WeeklyPlanDay>> GetIcPlanDay(string email, int day)
        {
            var getProfileResponse = await _userService.GetOrCreateByEmailAsync(email);

            if (day > 20 || day < 1)
            {
                return ServiceValueResponse<WeeklyPlanDay>.Error(ErrorCodes.InvalidOperation, 
                    $"Invalid day number: {day}. Day should be between 1 and 20");
            }

            if (!getProfileResponse.IsSuccess)
            {
                return ServiceValueResponse<WeeklyPlanDay>.FromErrors(getProfileResponse.Errors);
            }

            var weekNumber = ((day - 1) / 5) + 1;
            var dayNumber = (day - 1) % 5;

            var weekToReturn = await _weekRepository
                .Query()
                .Where(x => x.WeekNumber == (StudyWeek)weekNumber && x.UserId == getProfileResponse.Value.Id)
                .Include(nameof(WeeklyPlanWeek.Week))
                .FirstOrDefaultAsync();

            var dayToReturn = weekToReturn.Week[dayNumber];

            return ServiceValueResponse<WeeklyPlanDay>.Success(dayToReturn);
        }

        public async Task<ServiceValueResponse<IList<WeeklyPlanWeek>>> GetAllMissedWeeklyPlansAsync()
        {
            var missedWeeks = new List<WeeklyPlanWeek>();
            var profiles = await _erTicketRepository.GetAllAsync();

            if (profiles != null)
            {
                foreach (var profile in profiles)
                {
                    var userResponse = await _userService.GetOrCreateByEmailAsync(profile.CompanyEmail);
                    var user = userResponse.Value;
                    if (user != null && profile.StartDate.HasValue)
                    {
                        var currentWeek = profile.StartDate.Value.GetCurrentWeekNumber();
                        if (currentWeek >= 1 && currentWeek <= 4)
                        {
                            var weeklyPlan = await _weekRepository.GetWeeklyPlanForUserAndWeekAsync(
                                user.Id,
                                (StudyWeek)currentWeek);

                            if (weeklyPlan != null)
                            {
                                if (!weeklyPlan.Submitted)
                                {
                                    missedWeeks.Add(weeklyPlan);
                                }
                            }
                            else
                            {
                                var missedWeek = new WeeklyPlanWeek()
                                {
                                    Approved = false,
                                    Submitted = false,
                                    Week = null,
                                    WeekNumber = (StudyWeek)currentWeek,
                                    User = user
                                };
                                missedWeeks.Add(missedWeek);
                            }
                        }
                    }
                }
            }
            return ServiceValueResponse<IList<WeeklyPlanWeek>>.Success(missedWeeks);
        }

        private async Task<ServiceResponse> SavePlans(
            User user, 
            Profile profile,
            IList<WeeklyPlanWeek> plans,
            DayOfWeek deadLine)
        {
            if (plans != null)
            {
                var currentWeekPlan = plans
                    .OrderBy(x => (int)x.WeekNumber)
                    .FirstOrDefault(x => x.CanSubmit(profile.StartDate.Value, deadLine));

                if (currentWeekPlan != null)
                {
                    var weeklyPlanItem = await EntityRepository
                        .Query()
                        .Where(x => x.Id == currentWeekPlan.Id && x.UserId == user.Id)
                        .FirstOrDefaultAsync();

                    if (weeklyPlanItem == null)
                    {
                        await EntityRepository.InsertAsync(currentWeekPlan);
                    }
                    else
                    {
                        weeklyPlanItem.Submitted = true;
                        await UpdateWeeklyPlanDays(currentWeekPlan.Week);
                        await EntityRepository.UpdateAsync(weeklyPlanItem);
                    }

                    return ServiceResponse.Success();
                }
                else
                {
                    return ServiceResponse.Error(ErrorCodes.InvalidOperation, $"Plan can only be updated in {deadLine} for current week.");
                }
            }
            else
            {
                return ServiceResponse.Error(ErrorCodes.InvalidOperation, "No plan found.");
            }
        }

        private async Task<ServiceValueResponse<IList<WeeklyPlanWeek>>> GetAllWeeklyPlanForRcAsync(
            ServiceValueResponse<User> getProfileResponse)
        {
            var rcWeeklyPlanItems = await _weekRepository.GetAllAsync(getProfileResponse.Value.Id);
            var itemCount = rcWeeklyPlanItems?.Count;

            if (itemCount < BusinessConstants.WorkWeekCount)
            {
                await CreateInitialBlankPlan(getProfileResponse.Value.Id);
                rcWeeklyPlanItems = await _weekRepository.GetAllAsync(getProfileResponse.Value.Id);
            }

            return ServiceValueResponse<IList<WeeklyPlanWeek>>.Success(rcWeeklyPlanItems);
        }

        private async Task UpdateWeeklyPlanDays(ICollection<WeeklyPlanDay> weekDays)
        {
            foreach(var weekDay in weekDays)
            {
                var weekDayItem = await _dayRepository
                       .Query()
                       .Where(x => x.Id == weekDay.Id)
                       .FirstOrDefaultAsync();

                if(weekDay == null)
                {
                    await _dayRepository.InsertAsync(weekDay);
                }
                else
                {
                    weekDayItem.Summary = weekDay.Summary;
                    weekDayItem.ScoreTarget = weekDay.ScoreTarget;

                    await _dayRepository.UpdateAsync(weekDayItem);
                }
            }
        }

        private async Task CreateInitialBlankPlan(int userId)
        {
            for(var weekNumber = 1; weekNumber <= 4; weekNumber++)
            {
                var week = new WeeklyPlanWeek
                {
                    Approved = false,
                    Submitted = false,
                    WeekNumber = (StudyWeek)weekNumber,
                    UserId = userId,
                    Week = new List<WeeklyPlanDay>()
                };

                await _weekRepository.InsertAsync(week);

                for (var dayNumber = 1; dayNumber <= 5; dayNumber++)
                {
                    var day = new WeeklyPlanDay
                    {
                        Day = ((DayOfWeek)dayNumber).ToString(),
                        ScoreTarget = null,
                        Summary = null,
                        WeeklyPlanWeekId = week.Id
                    };

                    await _dayRepository.InsertAsync(day);
                }
            }
        }
    }
}
