using System.Threading.Tasks;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    public interface IEmailAlertService
    {
        Task SendEmailAlertForMissingWeeklyPlanSubmission();
    }
}
