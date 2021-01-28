using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using RemoteCamp.Portal.Core.Infrastructure.Services;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{
    class ProfileService : IProfileService
    {
        private readonly IErTicketRepository _erTicketRepository;

        public ProfileService(IErTicketRepository erTicketRepository)
        {
            _erTicketRepository = erTicketRepository;
        }

        public async Task<ServiceValueResponse<Profile>> GetAsync(string email)
        {
            var erTicket = await _erTicketRepository.GetByCompanyEmailAsync(email, ErTicketLoadOptions.Attachments);
            if (erTicket == null)
            {
                return ServiceValueResponse<Profile>.NotFound($"IC card by company email {email} was not found");
            }

            return ServiceValueResponse<Profile>.Success(ConvertToProfile(erTicket));
        }
        
        public async Task<ServiceValueResponse<IList<Profile>>> GetAllActiveAsync()
        {
            var erTickets = await _erTicketRepository.GetAllAsync();
            return ServiceValueResponse<IList<Profile>>.Success(erTickets.Select(ConvertToProfile).ToList());
        }

        public async Task<ServiceResponse> UpdateAsync(ProfileUpdateRequest profileUpdateRequest)
        {
            var erTicket = await _erTicketRepository.GetByCompanyEmailAsync(profileUpdateRequest.CompanyEmail);
            if (erTicket == null)
            {
                return ServiceResponse.NotFound($"IC card by company email {profileUpdateRequest.CompanyEmail} was not found");
            }

            var erTicketUpdateRequest = new ErTicketUpdateRequest
            {
                JiraKey = erTicket.JiraKey,
                UpdateContractUrl = true,
                ContractUrl = profileUpdateRequest.ContractUrl,
                UpdateDeckUrl = true,
                DeckUrl = profileUpdateRequest.DeckUrl,
                UpdateTmsUrl = true,
                TmsUrl = profileUpdateRequest.TmsUrl,
                UploadAttachmentInfo = profileUpdateRequest.UploadAttachmentInfo
            };

            await _erTicketRepository.UpdateAsync(erTicketUpdateRequest);
            return ServiceResponse.Success();
        }

        private static Profile ConvertToProfile(ErTicket erTicket)
        {
            return new Profile
            {
                CompanyEmail = erTicket.CompanyEmail,
                StartDate = erTicket.StartDate,
                Pipeline = erTicket.Pipeline,
                PipelineJiraId = erTicket.PipelineJiraId,
                Name = erTicket.Summary,
                ManagerJiraUser = erTicket.Assignee,
                IcName = erTicket.Summary,
                TmsUrl = erTicket.TmsUrl,
                ContractUrl = erTicket.Attachment.FirstOrDefault()?.FileName,
                DeckUrl = erTicket.DeckUrl,
                JiraId = erTicket.RcJiraId,
                XoId = erTicket.RcXoId,
                XoLoginEmail = erTicket.XoLoginEmail,
                AdAccount = erTicket.AdAccount,
                Status = erTicket.Status,
                IcRemoteUEnabled = !string.IsNullOrWhiteSpace(erTicket.IcRemoteU),
                EruStarted =
                    erTicket.StartEru?.Equals(JiraConstants.StartEruValues.Done, StringComparison.OrdinalIgnoreCase) ??
                    false,
                RemoteUModuleId = erTicket.RemoteUModuleId
            };
        }
    }
}
