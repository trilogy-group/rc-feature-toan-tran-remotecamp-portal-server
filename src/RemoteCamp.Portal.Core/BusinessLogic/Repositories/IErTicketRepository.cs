using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Data;

namespace RemoteCamp.Portal.Core.BusinessLogic.Repositories
{
    public interface IErTicketRepository
    {
        Task<ErTicket> GetByCompanyEmailAsync(string email, ErTicketLoadOptions loadOptions = ErTicketLoadOptions.None);

        Task<IList<ErTicket>> GetAllAsync();

        Task UpdateAsync(ErTicketUpdateRequest  erTicketUpdateRequest);

        Task<ErTicket> GetByXoEmailAsync(string email, ErTicketLoadOptions loadOptions = ErTicketLoadOptions.None);
    }

    [Flags]
    public enum ErTicketLoadOptions
    {
        None = 0,
        Attachments = 0x1
    }
}