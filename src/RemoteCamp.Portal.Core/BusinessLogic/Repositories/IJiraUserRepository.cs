using System;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Data;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public interface IJiraUserRepository
    {
        Task<JiraUser> GetByEmailAsync(string email, JiraUserLoadOptions loadOptions = JiraUserLoadOptions.None);
        Task<JiraUser> GetFullUserAsync(string accountId);
    }

    [Flags]
    public enum JiraUserLoadOptions
    {
        None = 0,
        Groups = 0x1
    }
}