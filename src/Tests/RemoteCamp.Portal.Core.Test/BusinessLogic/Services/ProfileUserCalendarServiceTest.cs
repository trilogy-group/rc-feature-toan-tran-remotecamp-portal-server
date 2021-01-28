using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Core.Test.Common;
using RemoteCamp.Portal.Core.Test.Helpers;
using Shouldly;
using Xunit;
using UserCalendarItem = RemoteCamp.Portal.Core.BusinessLogic.Data.UserCalendarItem;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Services
{
    public class ProfileUserCalendarServiceTest : UnitTestBase
    {
        private readonly ProfileUserCalendarService _profileUserCalendarService;

        public ProfileUserCalendarServiceTest()
        {
            _profileUserCalendarService = ServiceProvider.GetService<ProfileUserCalendarService>();
        }

        [Fact]
        public async Task GetAllAsync_UsersExists_ReturnsProfileUserCalendarByDayObject()
        {
            // Arrange
            const string email = "gaurav.thakur@aurea.com";
            var userCalendarItem = CreateUserCalendarItemObject();
            var user = CreateUserObject();

            var listUserCalendarItem = new List<UserCalendarItem>
            {
                userCalendarItem
            };
            ServiceProvider.GetMock<IProfileUserCalendarItemStatusRepository>()
                .Setup(x => x.GetAllAsync(1, CalendarType.EngRemoteU)).ReturnsAsync(listUserCalendarItem);
            ServiceProvider.GetMock<IUserService>()
                .Setup(x => x.GetOrCreateByEmailAsync(email)).ReturnsAsync(new ServiceValueResponse<User> { Value = user });

            var profile = CreateProfile(email);
            ServiceProvider.GetMock<IProfileService>()
                .Setup(x => x.GetAsync(email))
                .ReturnsAsync(ServiceValueResponse<Profile>.Success(profile));

            ServiceProvider.GetMock<IUserRepository>()
                .Setup(x => x.GetAsync(1)).ReturnsAsync(user);

            ServiceProvider.GetMock<ITemplater>()
                .Setup(x => x.Render(userCalendarItem.ActionUrl, profile))
                .Returns($"{userCalendarItem.ActionUrl}rendered");
            
            ServiceProvider.GetMock<ITemplater>()
                .Setup(x => x.Render(userCalendarItem.AdditionalActionUrl, profile))
                .Returns($"{userCalendarItem.AdditionalActionUrl}rendered");

            // Act
            var result = await _profileUserCalendarService.GetAllAsync(email);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.Count.ShouldBe(1),
                () =>
                {
                    var record = result.Value.FirstOrDefault();
                    this.ShouldSatisfyAllConditions(
                    () => record.ShouldNotBeNull(),
                    () => record.Week.ShouldNotBeNull(),
                    () => record.Week[0].Actions.ShouldNotBeNull(),
                    () => record.Week[0].Day.ShouldBe(DayOfWeek.Friday.ToString()),
                    () => record.Week[0].Description.ShouldBe(userCalendarItem.ItemDescription),
                    () => record.Week[0].Actions.Count.ShouldBe(1),
                    () => record.Week[0].Actions[0].IsCompleted.ShouldBeTrue(),
                    () => record.Week[0].Actions[0].Description.ShouldBe("Get"),
                    () => record.Week[0].Actions[0].AdditionalUrlDescription.ShouldBe("and read the welcome email from RemoteCamp management"),
                    () => record.Week[0].Actions[0].Url.ShouldBe($"{userCalendarItem.ActionUrl}rendered"),
                    () => record.Week[0].Actions[0].AdditionalUrl.ShouldBe($"{userCalendarItem.AdditionalActionUrl}rendered")
                    );
                });
        }

        [Fact]
        public async Task UpdateItemStatusAsync_UserCalendarItemStatusExist_UpdateRecord()
        {
            // Arrange
            const string email = "gaurav.thakur@aurea.com";
            var user = CreateUserObject();
            var listUserCalendarItemStatus = CreateUserCalendarItemStatusObject(user);

            ServiceProvider.GetMock<IProfileUserCalendarItemStatusRepository>()
                .Setup(mock => mock.Query())
                .Returns(new AsyncQueryResult<UserCalendarItemStatus>(listUserCalendarItemStatus));
            ServiceProvider.GetMock<IUserService>().
                Setup(mock => mock.GetOrCreateByEmailAsync(email)).ReturnsAsync(new ServiceValueResponse<User> { Value = user });
            ServiceProvider.GetMock<IUserRepository>().
                Setup(mock => mock.GetAsync(1)).ReturnsAsync(user);

            var profileUserCalendarService = ServiceProvider.GetService<ProfileUserCalendarService>();

            // Act
            var result = await profileUserCalendarService.UpdateItemStatusAsync(email, 1, true);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull());
        }

        [Fact]
        public async Task UpdateItemStatusAsync_UserCalendarItemStatusNotExist_AddNewRecord()
        {
            // Arrange
            const string email = "gaurav.thakur@aurea.com";
            var user = CreateUserObject();
            var listUserCalendarItemStatus = CreateUserCalendarItemStatusObject(user);

            ServiceProvider.GetMock<IProfileUserCalendarItemStatusRepository>()
                .Setup(mock => mock.Query())
                .Returns(new AsyncQueryResult<UserCalendarItemStatus>(listUserCalendarItemStatus));
            ServiceProvider.GetMock<IUserService>().
                            Setup(mock => mock.GetOrCreateByEmailAsync(email)).ReturnsAsync(new ServiceValueResponse<User> { Value = user });
            ServiceProvider.GetMock<IUserRepository>().
                Setup(mock => mock.GetAsync(1)).ReturnsAsync(user);

            var profileUserCalendarService = ServiceProvider.GetService<ProfileUserCalendarService>();

            // Act
            var result = await profileUserCalendarService.UpdateItemStatusAsync(email, 2, true);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull());
        }

        [Fact]
        public async Task GetAllMissedCalendarItemByEmailAsync_MissedCalendarItemsExists_ReturnsMissedCalendarItems()
        {
            // Arrange
            var remoteUStartDate = new DateTime(2020, 1, 6, 0, 0, 0, DateTimeKind.Utc);
            
            MockTimeService(remoteUStartDate.AddDays(4));
            const string email = "gaurav.thakur@aurea.com";
            var userCalendarItem = CreateUserCalendarItemObject();
            var user = CreateUserObject();

            var listUserCalendarItem = new List<UserCalendarItem>
            {
                userCalendarItem
            };
            ServiceProvider.GetMock<IProfileUserCalendarItemStatusRepository>()
                .Setup(x => x.GetAllMissedCalendarItemByUserIdAndDayAsync(1, CalendarType.EngRemoteU, 6))
                .ReturnsAsync(listUserCalendarItem);
            ServiceProvider.GetMock<IUserService>()
                .Setup(x => x.GetOrCreateByEmailAsync(email)).ReturnsAsync(new ServiceValueResponse<User> {Value = user});

            var profile = CreateProfile(email, startDate: remoteUStartDate);
            ServiceProvider.GetMock<IProfileService>()
                .Setup(x => x.GetAsync(email))
                .ReturnsAsync(ServiceValueResponse<Profile>.Success(profile));

            ServiceProvider.GetMock<IUserRepository>()
                .Setup(x => x.GetAsync(1)).ReturnsAsync(user);

            ServiceProvider.GetMock<ITemplater>()
                .Setup(x => x.Render(userCalendarItem.ActionUrl, profile))
                .Returns($"{userCalendarItem.ActionUrl}rendered");

            ServiceProvider.GetMock<ITemplater>()
                .Setup(x => x.Render(userCalendarItem.AdditionalActionUrl, profile))
                .Returns($"{userCalendarItem.AdditionalActionUrl}rendered");

            // Act
            var result = await _profileUserCalendarService.GetAllMissedCalendarItemByEmailAsync(email);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.Count.ShouldBe(1),
                () =>
                {
                    var record = result.Value.FirstOrDefault();
                    this.ShouldSatisfyAllConditions(
                        () => record.ShouldNotBeNull(),
                        () => record.Week.ShouldBe(0),
                        () => record.Day.ShouldBe(DayOfWeek.Friday.ToString()),
                        () => record.DayNumberInRemoteU.ShouldBe(-2),
                        () => record.ActionUrl1.ShouldBe($"{userCalendarItem.ActionUrl}rendered"),
                        () => record.ActionUrl2.ShouldBe($"{userCalendarItem.AdditionalActionUrl}rendered")
                    );
                });
        }

        private static List<UserCalendarItemStatus> CreateUserCalendarItemStatusObject(User user)
        {
            var userCalendarItemStatus = new UserCalendarItemStatus
            {
                Id = 1,
                IsCompleted = true,
                UserCalendarItemId = 1,
                UserId = 1,
                User = user
            };
            var listUserCalendarItemStatus = new List<UserCalendarItemStatus>
            {
                userCalendarItemStatus
            };
            return listUserCalendarItemStatus;
        }

        private static User CreateUserObject()
        {
            return new User
            {
                Id = 1,
                CreatedAt = DateTime.UtcNow,
                Email = "gaurav.thakur@aurea.com"
            };
        }

        private static UserCalendarItem CreateUserCalendarItemObject()
        {
            return new UserCalendarItem
            {
                Id = 1,
                Day = DayOfWeek.Friday.ToString(),
                ItemDescription = "You are technically and mentally prepared to the adventure. All is set up. Your assignments will be available on Monday.",
                WeekNumber = 0,
                ActionDescription = "Get and read the welcome email from RemoteCamp management",
                ActionUrl = "url1",
                AdditionalActionUrl = "additonalUrl1",
                Duration = 10,
                UserCalendarActionItemId = 1,
                IsCompleted = true,
            };
        }
        private static Profile CreateProfile(string companyEmail, DateTime? startDate = null)
        {
            return new Profile
            {
                CompanyEmail = companyEmail,
                DeckUrl = "http://test.deckurl",
                Pipeline = "C# (.NET) Software Engineer",
                XoId = 1,
                StartDate = startDate ?? DateTime.UtcNow,
                Status = "RC-Active",
                TmsUrl = "http://tms.url"
            };
        }
    }
}
