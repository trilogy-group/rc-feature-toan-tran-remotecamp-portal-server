using System;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Extensions;
using RemoteCamp.Portal.Core.Test.Common;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Extensions
{
    public class ProfileExtensionsTest : UnitTestBase
    {
        [Fact]
        public void GetCurrentWeekIndex_SecondWeek()
        {
            var profile = new Profile
            {
                StartDate = new DateTime(2019, 6, 10)
            };

            var currentWeek = profile.GetCurrentWeekIndex();

            var daysPast = (DateTime.Now - profile.StartDate).Value.Days;
            var expectedWeekNumber = (int)(daysPast / 7);

            currentWeek.ShouldBe(expectedWeekNumber);
        }
        
        [Fact]
        public void GetWeekIndex_SeventhDay_ReturnsOne()
        {
            var profile = new Profile
            {
                StartDate = new DateTime(2019, 6, 10)
            };

            var weekIndex = profile.GetWeekIndex(profile.StartDate.Value.AddDays(7));

            weekIndex.ShouldBe(1);
        }
        
        [Fact]
        public void GetDayIndex_SeventhDay_ReturnsSeven()
        {
            var profile = new Profile
            {
                StartDate = new DateTime(2019, 6, 10)
            };

            var weekIndex = profile.GetDayIndex(profile.StartDate.Value.AddDays(7));

            weekIndex.ShouldBe(7);
        }        
    }
}
