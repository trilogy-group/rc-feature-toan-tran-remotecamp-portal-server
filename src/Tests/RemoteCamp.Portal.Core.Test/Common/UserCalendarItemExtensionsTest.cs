using System;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.Common
{
    public static class UserCalendarItemExtensionsTest
    {
        [Theory]
        [InlineData(2, DayOfWeek.Sunday, 6)]
        [InlineData(1, DayOfWeek.Monday, 0)]
        [InlineData(0, DayOfWeek.Friday, 4)]
        public static void GetDayIndex_CorrectValues_ReturnsCorrectResult(
            int weekNumber,
            DayOfWeek dayOfWeek,
            int expectedDayIndex)
        {
            var userCalendarItem = new UserCalendarItem
            {
                WeekNumber = weekNumber,
                Day = dayOfWeek.ToString()
            };

            var dayIndex = userCalendarItem.GetDayIndex();
            
            dayIndex.ShouldBe(expectedDayIndex);
        }

        [Theory]
        [InlineData(2, DayOfWeek.Sunday, 13)]
        [InlineData(1, DayOfWeek.Tuesday, 1)]
        [InlineData(0, DayOfWeek.Friday, -3)]
        public static void GetRemoteUDayIndex_CorrectValues_ReturnsCorrectResult(
            int weekNumber,
            DayOfWeek dayOfWeek,
            int expectedDayIndex)
        {
            var userCalendarItem = new UserCalendarItem
            {
                WeekNumber = weekNumber,
                Day = dayOfWeek.ToString()
            };
            
            var dayIndex = userCalendarItem.GetRemoteUDayIndex();
            
            dayIndex.ShouldBe(expectedDayIndex);
        }
    }
}