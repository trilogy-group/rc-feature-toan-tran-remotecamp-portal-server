using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atlassian.Jira;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.ItOpsOnBoard;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Core.Utils;
using Serilog;

namespace RemoteCamp.Portal.Core.BusinessLogic.Services
{

    class RegistrationService : IRegistrationService
    {
        private readonly IErTicketRepository _erTicketRepository;
        private readonly IIcPipelineRepository _icPipelineRepository;
        private readonly IItOpsOnBoardAdapter _itOpsOnBoardAdapter;

        public RegistrationService(
            IErTicketRepository erTicketRepository,
            IIcPipelineRepository icPipelineRepository,
            IItOpsOnBoardAdapter itOpsOnBoardAdapter)
        {
            _erTicketRepository = erTicketRepository;
            _icPipelineRepository = icPipelineRepository;
            _itOpsOnBoardAdapter = itOpsOnBoardAdapter;
        }

        public async Task<ServiceResponse> CreateAsync(RegistrationCreateRequest request)
        {
            if (request.SignedContract == null || request.SignedContract.Length == 0)
            {
                return ServiceResponse.Error(ErrorCodes.BadRequest, "Signed contract is required");
            }

            if (string.IsNullOrWhiteSpace(request.VideoUrl))
            {
                return ServiceResponse.Error(ErrorCodes.BadRequest, "Video is required");
            }

            var erTicket = await _erTicketRepository.GetByXoEmailAsync(request.Email);
            if (erTicket == null)
            {
                return ServiceResponse.NotFound("User by XO Login Email was not found. Please contact to remotecamp-sem@trilogy.com");
            }

            if (!string.IsNullOrWhiteSpace(erTicket.CompanyEmail) 
                || !erTicket.Status.Equals(JiraConstants.ErTicketStatuses.RcCandidate, StringComparison.OrdinalIgnoreCase))
            {
                return ServiceResponse.Error(ErrorCodes.BadRequest, "User already registered");
            }

            var rcPipeline = await _icPipelineRepository.GetAsync(request.Role);
            if (rcPipeline == null)
            {
                return ServiceResponse.Error(ErrorCodes.BadRequest, "Something wrong with the selected role");
            }

            if ((string.IsNullOrWhiteSpace(request.GitHubId) && !BusinessConstants.QaManualTesterIds.Contains(rcPipeline.Id)))
            {
                return ServiceResponse.Error(ErrorCodes.BadRequest, "GitHubId is required");
            }

            await UpdateErTicket(erTicket, request, rcPipeline);
            
            await MoveToStageStatus(erTicket);

            await CreateItOpsTicket(erTicket, rcPipeline);

            return ServiceResponse.Success();
        }

        private async Task UpdateErTicket(ErTicket erTicket, RegistrationCreateRequest request, IcPipeline rcPipeline)
        {
            var updateRequest = new ErTicketUpdateRequest
            {
                JiraKey = erTicket.JiraKey,

                UpdateStartDate = true,
                StartDate = request.StartDate,

                UpdatePipeline = true,
                Pipeline = rcPipeline.Name,

                UpdateVideoOfPurpose = true,
                VideoOfPurpose = request.VideoUrl,

                UploadAttachmentInfo = new List<UploadAttachmentInfo>
                {
                    new UploadAttachmentInfo("Signed Contract", request.SignedContract)
                },

                UpdateGitHubId = !BusinessConstants.QaManualTesterIds.Contains(rcPipeline.Id),
                GitHubId = request.GitHubId
            };

            await _erTicketRepository.UpdateAsync(updateRequest);
        }

        private async Task MoveToStageStatus(ErTicket erTicket)
        {
            var transitionRequest = new ErTicketUpdateRequest
            {
                JiraKey = erTicket.JiraKey,
                TransitionName = JiraConstants.ErTicketTransitions.PickADateTransitionName
            };
            try
            {
                await _erTicketRepository.UpdateAsync(transitionRequest);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Error occurred while transitioning {transitionRequest.JiraKey} with {transitionRequest.TransitionName}");
            }
        }

        private async Task CreateItOpsTicket(ErTicket erTicket, IcPipeline rcPipeline)
        {
            await _itOpsOnBoardAdapter.SendAsync(new ItOpsOnBoardRequest
            {
                Name = erTicket.Name,
                Email = erTicket.XoLoginEmail,
                Pipeline = rcPipeline.Name,
                Manager = erTicket.HiringManager,
                Application360Link = erTicket.Application360Link
            });
        }
    }
}
