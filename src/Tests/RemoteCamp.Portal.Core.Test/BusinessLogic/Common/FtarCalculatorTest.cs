using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using Shouldly;
using System;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Common
{
    public class FtarCalculatorTest
    {
        [Fact]
        public void CalculateActualValue_WeekIs2_ReturnScore()
        {
            // Arrange
            var mondayWeek2 = DateTime.Today.AddDays(-(int) DateTime.Today.DayOfWeek + (int) DayOfWeek.Monday - 7);
            var rcTasks = new[]
            {
                new RcTask
                {
                    FirstSubmissionDate = mondayWeek2.AddDays(1),
                    Ftar = true
                },
                new RcTask
                {
                    FirstSubmissionDate = mondayWeek2.AddDays(1),
                    Status = "In Review"
                },
                new RcTask
                {
                    FirstSubmissionDate = mondayWeek2.AddDays(1),
                    Ftar = false
                }
            };


            // Act
            var ftarCalculator = new FtarCalculator();
            var ftarResult = ftarCalculator.CalculateActualValue(rcTasks, mondayWeek2, true);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => ftarResult.ShouldNotBeNull(),
                () => ftarResult.Value.ShouldBe(0.66d, 0.01)
            );
        }

        [Fact]
        public void GivenApprovedWhenCalledCalculateWithInReviewAndWeekIs2ThenReturnNull()
        {
            // Arrange
            var mondayWeek2 = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday - 7);
            var rcTasks = new[]
            {
                new RcTask
                {
                    FirstSubmissionDate = mondayWeek2.AddDays(1),
                    Ftar = true
                },
                new RcTask
                {
                    FirstSubmissionDate = mondayWeek2.AddDays(1),
                    Status = "In Review"
                },
                new RcTask
                {
                    FirstSubmissionDate = mondayWeek2.AddDays(1),
                    Ftar = false
                }
            };
            
            // Act
            var ftarCalculator = new FtarCalculator();
            var ftarResult = ftarCalculator.CalculateGraduationValue(rcTasks, mondayWeek2, true);

            // Assert
            ftarResult.ShouldBeNull();
        }

        [Fact]
        public void GivenApprovedWhenCalledCalculateWithInReviewFlagAsTrueThenReturnScore()
        {
            // Arrange
            var mondayWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            var startDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday - 21);
            var rcTasks = new[]
            {
                new RcTask
                {
                    Ftar = true,
                    FirstSubmissionDate = mondayWeek
                },
                new RcTask
                {
                    Status = "In Review",
                    FirstSubmissionDate = mondayWeek
                },
                new RcTask
                {
                    Ftar = false,
                    FirstSubmissionDate = mondayWeek
                },
                new RcTask
                {
                    Ftar = false,
                    Status = "In Review",
                    FirstSubmissionDate = mondayWeek
                }
            };

            // Act
            var ftarCalculator = new FtarCalculator();
            var ftarResult = ftarCalculator.CalculateGraduationValue(rcTasks, startDate, true);

            // Assert
            ftarResult.ShouldBe(0.5);
        }

        [Fact]
        public void GivenApprovedWhenCalledCalculateWithInReviewFlagAsFalseThenReturnScore()
        {
            // Arrange
            var mondayWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            var startDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday - 21);
            var rcTasks = new[]
            {
                new RcTask
                {
                    Ftar = true,
                    FirstSubmissionDate = mondayWeek
                },
                new RcTask
                {
                    Status = "In Review",
                    FirstSubmissionDate = mondayWeek
                },
                new RcTask
                {
                    Ftar = false,
                    Status = "In Review",
                    FirstSubmissionDate = mondayWeek
                }
            };

            // Act
            var ftarCalculator = new FtarCalculator();
            var ftarResult = ftarCalculator.CalculateGraduationValue(rcTasks, startDate, false);

            // Assert
            ftarResult.ShouldBe(0.5);
        }
    }
}