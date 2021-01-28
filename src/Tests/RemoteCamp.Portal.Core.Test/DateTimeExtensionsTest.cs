using System;
using System.Collections.Generic;
using System.Text;
using RemoteCamp.Portal.Core.Utils;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test
{
    public class DateTimeExtensionsTest
    {
        [Theory]
        [InlineData("2019-07-29", 31)]
        [InlineData("2019-08-05", 32)]
        [InlineData("2019-08-12", 33)]
        [InlineData("2019-07-19", 29)]
        public void GetIso8601WeekOfYear_CorrectDate_ReturnsCorrectWeekNumber(string dateTimeText, int expectedWeekNumber)
        {
            var dateTime = DateTime.Parse(dateTimeText);
            var actualWeekNumber = dateTime.GetIso8601WeekOfYear();
            actualWeekNumber.ShouldBe(expectedWeekNumber);
        }

        [Theory]
        [InlineData("2019-12-01", 19)]
        [InlineData("2019-01-02", 19)]
        [InlineData("2019-12-30", 20)]
        [InlineData("2020-12-28", 21)]
        [InlineData("2021-12-29", 22)]
        [InlineData("2022-12-30", 23)]
        [InlineData("2023-12-31", 24)]
        public void GetYearFromStartDate_CorrectDate_ReturnsCorrectWeekNumber(string dateTimeText, int expectedYearNumber)
        {
            var dateTime = DateTime.Parse(dateTimeText);
            var actualYearNumber = dateTime.GetYearFromStartDate();
            actualYearNumber.ShouldBe(expectedYearNumber);
        }
    }
}
