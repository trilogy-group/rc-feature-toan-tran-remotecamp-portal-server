using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RemoteCamp.Portal.Core.BusinessLogic.Common;
using RemoteCamp.Portal.Core.BusinessLogic.Data;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.Common;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using RemoteCamp.Portal.Core.Test.Common;
using RemoteCamp.Portal.Core.Utils;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Common
{
    public class RcTaskLoaderTest : UnitTestBase
    {
        [Fact]
        public async void LoadAsync_DataExists_ReturnsTickets()
        {
            // Arrange
            var utcNow = DateTime.UtcNow.Date;

            var riqbItems = new List<RiqbItem>
            {
                new RiqbItem
                {
                    JiraKey = "RIQB-1",
                    Summary = "Summary1"
                },
                new RiqbItem
                {
                    JiraKey = "RIQB-2",
                    Summary = "Summary2"
                }
            };

            var rcTasks = new List<RcTask>
            {
                new RcTask
                {
                    JiraKey = "REM-1",
                    Summary = "Summary REM-1",
                    Status = JiraConstants.RcTaskStatuses.Approved,
                    FailedIqbs = new List<RiqbItem> {riqbItems[0]}
                },
                new RcTask
                {
                    JiraKey = "REM-2",
                    Summary = "Summary REM-2",
                    Reviews = new List<RcReview>
                    {
                        new RcReview
                        {
                            JiraKey = "REM-3"
                        }
                    }
                }
            };

            var rcReviews = new List<RcReview>
            {
                new RcReview
                {
                    JiraKey = "REM-3",
                    FailedIqbs = new List<RiqbItem> {riqbItems[0], riqbItems[1]},
                }
            };
            var startDate = new DateTime(2019, 6, 17);
            var profile = new Profile
            {
                StartDate = startDate,
                Status = "RC Active",
                CompanyEmail = "jon.snow@mail.test",
                JiraId = "JiraId1"
            };

            var requestDateRange = new Range<DateTime>(utcNow.AddDays(-28), utcNow.AddDays(1));

            ServiceProvider.GetMock<ITimeService>()
                .SetupGet(x => x.UtcNow)
                .Returns(DateTime.UtcNow);

            ServiceProvider.GetMock<IRcTaskJiraRepository>()
                .Setup(
                    x => x.FindFailedByAssigneeAndDatesAsync(profile.JiraId, requestDateRange, RcTaskLoadOptions.All))
                .ReturnsAsync(rcTasks);

            ServiceProvider.GetMock<IRcReviewJiraRepository>()
                .Setup(x => x.FindByRcTaskAsync("REM-2")).ReturnsAsync(rcReviews);

            var loader = ServiceProvider.GetService<RcTaskLoader>();

            // Act
            var result = await loader.LoadAsync(profile);

            // Arrange
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Count.ShouldBe(2),
                () => result[0].JiraKey.ShouldBe(rcTasks[0].JiraKey),
                () => result[1].JiraKey.ShouldBe(rcTasks[1].JiraKey),
                () => result[1].Reviews.ShouldNotBeNull(),
                () => result[1].Reviews.Count.ShouldBe(1),
                () => result[1].Reviews[0].JiraKey.ShouldBe(rcReviews[0].JiraKey),
                () => result[1].Reviews[0].FailedIqbs.ShouldNotBeNull(),
                () => result[1].Reviews[0].FailedIqbs.Count.ShouldBe(2),
                () => result[1].Reviews[0].FailedIqbs[0].JiraKey.ShouldBe(riqbItems[0].JiraKey),
                () => result[1].Reviews[0].FailedIqbs[1].JiraKey.ShouldBe(riqbItems[1].JiraKey)
            );
        }
    }
}