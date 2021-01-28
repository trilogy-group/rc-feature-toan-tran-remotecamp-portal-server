using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Test.Common;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Services
{
    public class ProfileServiceTest : UnitTestBase
    {
        private readonly ProfileService _profileService;

        public ProfileServiceTest()
        {
            _profileService = ServiceProvider.GetService<ProfileService>();
        }

        [Fact]
        public async Task GetAsync_UsersExists_ReturnsProfileObject()
        {
            // Arrange
            const string email = "jon.snow@mail.test";
            const int pipelineJiraId = 11853;
            var erTicket = CreateErTicketObject(email);
            ServiceProvider.GetMock<IErTicketRepository>()
                .Setup(x => x.GetByCompanyEmailAsync(It.IsAny<string>(), It.IsAny<ErTicketLoadOptions>())).ReturnsAsync(erTicket);

            // Act
            var result = await _profileService.GetAsync(email);

            // Assert
            this.ShouldSatisfyAllConditions(
              () => result.ShouldNotBeNull(),
              () => result.Value.ShouldNotBeNull(),
              () =>
              {
                  var profile = result.Value;
                  this.ShouldSatisfyAllConditions(
                      () => profile.ShouldNotBeNull(),
                      () => profile.XoId.ShouldBe(1),
                      () => profile.CompanyEmail.ShouldBe(email),
                      () => profile.DeckUrl.ShouldBe(erTicket.DeckUrl),
                      () => profile.TmsUrl.ShouldBe(erTicket.TmsUrl),
                      () => profile.IcName.ShouldBe(erTicket.Summary),
                      () => profile.PipelineJiraId.ShouldBe(pipelineJiraId),
                      () => profile.IcRemoteUEnabled.ShouldBeTrue(),
                      () => profile.RemoteUModuleId.ShouldBe(erTicket.RemoteUModuleId)
                  );
              });
        }

        [Fact]
        public async Task UpdateProfileDetailAsync_UsersExists_UpdateErTicketObject()
        {
            // Arrange
            var profile = CreateProfileUpdateRequestObject();
            var erTicket = CreateErTicketObject(profile.CompanyEmail);
            ServiceProvider.GetMock<IErTicketRepository>()
                .Setup(x => x.GetByCompanyEmailAsync(profile.CompanyEmail, ErTicketLoadOptions.None))
                .ReturnsAsync(erTicket);
            ServiceProvider.GetMock<IErTicketRepository>()
                .Setup(x => x.UpdateAsync(It.IsAny<ErTicketUpdateRequest>()));

            // Act
            var result = await _profileService.UpdateAsync(profile);

            // Assert
            this.ShouldSatisfyAllConditions(
              () => result.ShouldNotBeNull(),
              () => result.IsSuccess.ShouldBeTrue());
        }

        private static ErTicket CreateErTicketObject(string companyEmail)
        {
            return new ErTicket
            {
                CompanyEmail = companyEmail,
                Assignee = new JiraUserValue
                {
                    AccountId = "test"
                },
                DeckUrl = "http://test.deckurl",
                JiraKey = "REM-121",
                Pipeline = "C# (.NET) Software Engineer",
                PipelineJiraId = 11853,
                RcJiraId = "absc1234",
                RcXoId = 1,
                StartDate = DateTime.UtcNow,
                Status = "RC-Active",
                Summary = "Test User",
                TmsUrl = "http://tms.url",
                IcRemoteU = "Joined",
                RemoteUModuleId = 2
            };
        }

        private static ProfileUpdateRequest CreateProfileUpdateRequestObject()
        {
            return new ProfileUpdateRequest
            {
                DeckUrl = "http://test.deckurl",
                TmsUrl = "http://tms.url",
                CompanyEmail = "jon.snow@mail.test"
            };
        }
    }
}
