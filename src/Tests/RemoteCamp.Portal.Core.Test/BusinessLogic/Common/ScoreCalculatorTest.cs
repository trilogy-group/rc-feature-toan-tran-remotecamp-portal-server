using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using Shouldly;
using System;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Common
{
    public class ScoreCalculatorTest
    {
        [Theory]
        [InlineData(0, 0.75, 3.75)]
        [InlineData(-7, 4.25, 6.25)]
        [InlineData(-14, 7.0, 10.0)]
        [InlineData(-21, 11.0, 15.0)]
        public void CalculateDailyTarget_GivenWeek_ReturnsScore(int week, double min, double max)
        {
            // Arrange
            var weekMonday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday + week);

            var calculator = new ScoreCalculator();

            // Act
            var dailyTarget = calculator.CalculateDailyTarget(weekMonday);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => dailyTarget.ShouldBeGreaterThanOrEqualTo(min),
                () => dailyTarget.ShouldBeLessThanOrEqualTo(max));
        }
    }
}
