using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atlassian.Jira;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.Integration.BusinessLogic.Repositories
{
    public class ErTicketRepositoryTest
    {
        [Fact(Skip = "Set another JiraKey")]
        public async void UpdateAsync_ErTicketExists_UploadsAttachments()
        {
            var applicationOption = TestApplicationOptionsFactory.Default.Create();
            var repository =
                new ErTicketRepository(new JiraClientAdapter(applicationOption), applicationOption);

            var updateRequest = new ErTicketUpdateRequest
            {
                JiraKey = "ER-1189",
                UploadAttachmentInfo = new List<UploadAttachmentInfo>
                {
                    new UploadAttachmentInfo("test", new byte[] { 1, 2, 3 })
                }
            };

            // Act & Assert 
            await repository.UpdateAsync(updateRequest);
        }

        [Fact(Skip = "Set another JiraKey")]
        public async void UpdateAsync_ErTicketExists_UpdatesPipeline()
        {
            var applicationOption = TestApplicationOptionsFactory.Default.Create();
            var repository =
                new ErTicketRepository(new JiraClientAdapter(applicationOption), applicationOption);

            var updateRequest = new ErTicketUpdateRequest
            {
                JiraKey = "ER-1189",
                UpdatePipeline = true,
                Pipeline = "Java Software Architect"
            };

            await repository.UpdateAsync(updateRequest);
        }

        [Fact(Skip = "Set another JiraKey")]
        public async void UpdateAsync_ErTicketExists_UpdatesStartDate()
        {
            var applicationOption = TestApplicationOptionsFactory.Default.Create();
            var repository =
                new ErTicketRepository(new JiraClientAdapter(applicationOption), applicationOption);

            var updateRequest = new ErTicketUpdateRequest
            {
                JiraKey = "ER-1189",
                UpdateStartDate = true,
                StartDate = DateTime.UtcNow.AddDays(-1)
            };

            await repository.UpdateAsync(updateRequest);
        }

        [Fact()]
        public async Task GetAllAsync_ReturnsErTickets()
        {
            // Arrange 
            var applicationOption = TestApplicationOptionsFactory.Default.Create();
            applicationOption.JiraSettings.IcCardProject = "TER";
            var repository =
                new ErTicketRepository(new JiraClientAdapter(applicationOption), applicationOption);

            // Act 
            var tickets = await repository.GetAllAsync();

            // Assert
            tickets.ShouldNotBeNull();

            if (tickets.Count > 0)
            {
                this.ShouldSatisfyAllConditions(
                    () => tickets.ShouldAllBe(x => x.XoLoginEmail != null),
                    () => tickets.ShouldAllBe(x => x.JiraKey != null),
                    () => tickets.ShouldAllBe(x => x.Summary != null),
                    () => tickets.ShouldAllBe(x => x.XoLoginEmail != x.RcXoId.ToString()));
            }
        }
    }
}
