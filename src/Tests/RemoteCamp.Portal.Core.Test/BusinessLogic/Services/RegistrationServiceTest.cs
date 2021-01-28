using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using KellermanSoftware.CompareNetObjects;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Infrastructure.ItOpsOnBoard;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using RemoteCamp.Portal.Core.Test.Common;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Services
{
    public class RegistrationServiceTest : UnitTestBase
    {
        [Fact]
        public async void CreateAsync_ErTicketExists_Updates()
        {
            var service = ServiceProvider.GetService<RegistrationService>();

            var erTicket = new ErTicket
            {
                JiraKey = "ER-1",
                Status = JiraConstants.ErTicketStatuses.RcCandidate
            };

            var icPipeline = new IcPipeline
            {
                Id = 1,
                Name = "Java Software Architect"
            };

            var registrationCreateRequest = new RegistrationCreateRequest
            {
                Email = "jon.snow@mail.test",
                Role = 1,
                StartDate = new DateTime(2019, 8, 12),
                SignedContract = new byte[1],
                VideoUrl = "http://video.test",
                GitHubId = "jon-snow-aurea"
            };

            var expectedUpdateRequest = new ErTicketUpdateRequest
            {
                JiraKey = erTicket.JiraKey,

                UpdateStartDate = true,
                StartDate = registrationCreateRequest.StartDate,

                UpdatePipeline = true,
                Pipeline = icPipeline.Name,

                UpdateVideoOfPurpose = true,
                VideoOfPurpose = registrationCreateRequest.VideoUrl,
                UpdateGitHubId = true,
                GitHubId = registrationCreateRequest.GitHubId
            };

            var updatedErTicket = new ErTicket
            {
                JiraKey = "ER-1",
                Name = "Jon Snow",
                XoLoginEmail = registrationCreateRequest.Email,
                Pipeline = icPipeline.Name,
                HiringManager = "Dayneris Targarien"
            };

            var itOpsRequest = new ItOpsOnBoardRequest
            {
                Name = updatedErTicket.Name,
                Email = updatedErTicket.XoLoginEmail,
                Manager = updatedErTicket.HiringManager,
                Pipeline = updatedErTicket.Pipeline
            };

            ServiceProvider.GetMock<IErTicketRepository>()
                .Setup(x => x.GetByXoEmailAsync(registrationCreateRequest.Email, ErTicketLoadOptions.None))
                .ReturnsAsync(erTicket);

            ServiceProvider.GetMock<IIcPipelineRepository>()
                .Setup(x => x.GetAsync(registrationCreateRequest.Role))
                .ReturnsAsync(icPipeline);

            ServiceProvider.GetMock<IErTicketRepository>()
                .Setup(x => x.UpdateAsync(It.Is(IsEqual(expectedUpdateRequest))));

            ServiceProvider.GetMock<IItOpsOnBoardAdapter>()
                .Setup(x => x.SendAsync(It.Is(IsEqual(itOpsRequest))))
                .ReturnsAsync(true);

            var response = await service.CreateAsync(registrationCreateRequest);

            this.ShouldSatisfyAllConditions(
                () => response.IsSuccess.ShouldBeTrue()
                );

            var expectedTransitionRequest = new ErTicketUpdateRequest()
            {
                JiraKey = erTicket.JiraKey,
                TransitionName = "Pick a date"
            };
            ServiceProvider.GetMock<IErTicketRepository>()
                .Verify(x => x.UpdateAsync(It.Is(IsEqual(expectedTransitionRequest))));

            ServiceProvider.GetMock<IErTicketRepository>()
                .Verify(x => x.UpdateAsync(It.Is(IsEqual(expectedUpdateRequest))));
        }

        public Expression<Func<ItOpsOnBoardRequest, bool>> IsEqual(ItOpsOnBoardRequest request)
        {
            return x => new CompareLogic(new ComparisonConfig
            {
                MembersToIgnore = new List<string>
                {
                    nameof(ErTicketUpdateRequest.UploadAttachmentInfo)
                }
            }).Compare(x, request).AreEqual;
        }

        public Expression<Func<ErTicketUpdateRequest, bool>> IsEqual(ErTicketUpdateRequest request)
        {
            return x => new CompareLogic(new ComparisonConfig
            {
                MembersToIgnore = new List<string>
                {
                    nameof(ErTicketUpdateRequest.UploadAttachmentInfo)
                }
            }).Compare(x, request).AreEqual;
        }
    }
}
