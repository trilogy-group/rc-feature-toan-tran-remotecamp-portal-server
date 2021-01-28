using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public interface IWeeklyPlanService : IGenericService<WeeklyPlanWeek>
    {
        Task<ServiceValueResponse<IList<WeeklyPlanWeek>>> GetAllAsync(string email);
        Task<ServiceResponse> SubmitPlansAsync(string email, IList<WeeklyPlanWeek> plans, DayOfWeek deadLine);
        Task<ServiceResponse> ChangeWeelyPlanApprovalAsync(string rcEmail, bool isApproved, StudyWeek weekNumber);
        Task<ServiceValueResponse<WeeklyPlanDay>> GetIcPlanDay(string email, int day);
        Task<ServiceValueResponse<IList<WeeklyPlanWeek>>> GetAllMissedWeeklyPlansAsync();
    }
}
