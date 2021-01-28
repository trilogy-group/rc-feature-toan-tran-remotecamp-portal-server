using System;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Infrastructure.Services;
using RemoteCamp.Portal.Core.Test.Common;
using RemoteCamp.Portal.Core.Test.Helpers;
using Shouldly;
using Xunit;
using UserCalendarItem = RemoteCamp.Portal.Core.Database.Model.UserCalendarItem;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Services
{
    public class UserCalendarDayServiceTest : UnitTestBase
    {
        [Fact]
        public async void GetByDateAsync_CalendarItemExists_ReturnsResult()
        {
            var profile = new Profile
            {
                CompanyEmail = "jon.snow@mail.test",
                IcRemoteUEnabled = true,
                StartDate = new DateTime(2020, 1, 6)
            };
            var requestedDate = profile.StartDate.Value.AddDays(4);

            var userCalendarItems = new []
            {
                new UserCalendarItem
                {
                    Day = DayOfWeek.Monday.ToString(),
                    WeekNumber = 1,
                    Header = "header1",
                    Description = "description1",
                    CalendarType = CalendarType.ICRemoteU
                },
                new UserCalendarItem
                {
                    Day = DayOfWeek.Friday.ToString(),
                    WeekNumber = 1,
                    Header = "header2",
                    Description = "description2",
                    CalendarType = CalendarType.ICRemoteU
                }
            };
            
            var service = ServiceProvider.GetService<UserCalendarDayService>();

            ServiceProvider.GetMock<IProfileService>()
                .Setup(x => x.GetAsync(profile.CompanyEmail))
                .ReturnsAsync(ServiceValueResponse<Profile>.Success(profile));
            
            ServiceProvider.GetMock<IUserCalendarItemRepository>()
                .Setup(x => x.Query())
                .Returns(new AsyncQueryResult<UserCalendarItem>(userCalendarItems));

            var userCalendarDayResponse = await service.GetByDateAsync(profile.CompanyEmail, requestedDate);

            this.ShouldSatisfyAllConditions(
                () => userCalendarDayResponse.IsSuccess.ShouldBeTrue(),
                () => userCalendarDayResponse.Value.DayNumber.ShouldBe(5),
                () => userCalendarDayResponse.Value.WeekNumber.ShouldBe(1),
                () => userCalendarDayResponse.Value.DayOfWeek.ShouldBe(DayOfWeek.Friday.ToString()),
                () => userCalendarDayResponse.Value.Details.ShouldNotBeNull(),
                () => userCalendarDayResponse.Value.Details.Header.ShouldBe(userCalendarItems[1].Header),
                () => userCalendarDayResponse.Value.Details.Description.ShouldBe(userCalendarItems[1].Description)
            );
        } 
        
        [Fact]
        public async void GetByDateAsync_CalendarItemDoesNotExist_ReturnsResultWithoutDetails()
        {
            var profile = new Profile
            {
                CompanyEmail = "jon.snow@mail.test",
                IcRemoteUEnabled = true,
                StartDate = new DateTime(2020, 1, 6)
            };
            var requestedDate = profile.StartDate.Value.AddDays(4);

            var service = ServiceProvider.GetService<UserCalendarDayService>();

            ServiceProvider.GetMock<IProfileService>()
                .Setup(x => x.GetAsync(profile.CompanyEmail))
                .ReturnsAsync(ServiceValueResponse<Profile>.Success(profile));
            
            ServiceProvider.GetMock<IUserCalendarItemRepository>()
                .Setup(x => x.Query())
                .Returns(new AsyncQueryResult<UserCalendarItem>(new UserCalendarItem[0]));

            var userCalendarDayResponse = await service.GetByDateAsync(profile.CompanyEmail, requestedDate);

            this.ShouldSatisfyAllConditions(
                () => userCalendarDayResponse.IsSuccess.ShouldBeTrue(),
                () => userCalendarDayResponse.Value.DayNumber.ShouldBe(5),
                () => userCalendarDayResponse.Value.WeekNumber.ShouldBe(1),
                () => userCalendarDayResponse.Value.DayOfWeek.ShouldBe(DayOfWeek.Friday.ToString()),
                () => userCalendarDayResponse.Value.Details.ShouldBeNull()
            );
        }         
    }
}