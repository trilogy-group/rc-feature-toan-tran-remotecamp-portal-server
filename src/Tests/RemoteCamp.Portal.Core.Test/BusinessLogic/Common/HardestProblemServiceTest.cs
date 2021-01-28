using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.Infrastructure.Common;
using RemoteCamp.Portal.Core.Test.Common;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Common
{
    public class HardestProblemServiceTest : UnitTestBase
    {
        [Fact]
        public void GetHardestProblemsByDay_CorrectData_ReturnHardestProblems()
        {
            // Arrange
            var service = ServiceProvider.GetService<HardestProblemService>();
            var profile = new Profile
            {
                StartDate = new DateTime(2020, 01, 6, 0, 0, 0, DateTimeKind.Utc),
            };

            var now = profile.StartDate.Value.AddDays(9);

            ServiceProvider.GetMock<ITimeService>()
                .SetupGet(x => x.UtcNow)
                .Returns(now);

            var rcTasks = new List<RcTask>
            {
                new RcTask
                {
                    JiraKey = "rem-1",
                    Summary = "task1",
                    FirstSubmissionDate = profile.StartDate.Value,
                    Reviews = new List<RcReview>
                    {
                        new RcReview
                        {
                            JiraKey = "review-1",
                            Summary = "review1",
                            FailedIqbs = new List<RiqbItem>
                            {
                                new RiqbItem
                                {
                                    JiraKey = "riqb-1",
                                    Summary = "riqb1"
                                }
                            }
                        }
                    }
                },
                new RcTask
                {
                    JiraKey = "rem-2",
                    Summary = "task2",
                    FirstSubmissionDate = now.AddDays(-1),
                    Reviews = new List<RcReview>
                    {
                        new RcReview
                        {
                            JiraKey = "review-2",
                            Summary = "review2",
                            FailedIqbs = new List<RiqbItem>
                            {
                                new RiqbItem
                                {
                                    JiraKey = "riqb-2",
                                    Summary = "riqb2"
                                }
                            }
                        }
                    }
                }
            };

            // Act
            var result = service.GetHardestProblemsByDay(rcTasks, profile);
            
            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Count.ShouldBe(8),
                
                () => result[0].Items.Count.ShouldBe(1),
                () => result[0].Items[0].JiraKey.ShouldBe(rcTasks[0].Reviews[0].FailedIqbs[0].JiraKey),
                () => result[0].Items[0].Summary.ShouldBe(rcTasks[0].Reviews[0].FailedIqbs[0].Summary),
                () => result[0].Items[0].Resolved.ShouldBeTrue(),
                () => result[0].Items[0].FailedIn.Count.ShouldBe(1),
                () => result[0].Items[0].FailedIn[0].JiraKey.ShouldBe(rcTasks[0].JiraKey),
                () => result[0].Items[0].FailedIn[0].Summary.ShouldBe(rcTasks[0].Summary),
                
                () => result[6].Items.Count.ShouldBe(1),
                () => result[6].Items[0].JiraKey.ShouldBe(rcTasks[1].Reviews[0].FailedIqbs[0].JiraKey),
                () => result[6].Items[0].Summary.ShouldBe(rcTasks[1].Reviews[0].FailedIqbs[0].Summary),
                () => result[6].Items[0].Resolved.ShouldBeFalse(),
                () => result[6].Items[0].FailedIn.Count.ShouldBe(1),
                () => result[6].Items[0].FailedIn[0].JiraKey.ShouldBe(rcTasks[1].JiraKey),
                () => result[6].Items[0].FailedIn[0].Summary.ShouldBe(rcTasks[1].Summary)
                );
            ;
            
            
            
        }
    }
}