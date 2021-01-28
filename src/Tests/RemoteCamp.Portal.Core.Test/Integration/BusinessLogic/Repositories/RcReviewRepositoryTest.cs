using System;
using System.Linq;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using RemoteCamp.Portal.Core.Utils;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.Integration.BusinessLogic.Repositories
{
    public class RcReviewRepositoryTest
    {
        [Fact]
        public async void FindByRcTaskAsync_TicketsExists_ReturnsTickets()
        {
            var repository = new RcReviewJiraRepository(new JiraClientAdapter(TestApplicationOptionsFactory.Default.Create()));

            var rcReviews = await repository.FindByRcTaskAsync("REM-102880");

            rcReviews.ShouldNotBeNull();

            if (rcReviews.Count > 0)
            {
                this.ShouldSatisfyAllConditions(
                    () => rcReviews.ShouldAllBe(x => x.Status != null),
                    () => rcReviews.ShouldAllBe(x => x.JiraKey != null),
                    () => rcReviews.ShouldAllBe(x => x.Summary != null),
                    () => rcReviews.ShouldAllBe(x => x.FailedIqbs == null || x.FailedIqbs.All(y => y.JiraKey != null)),
                    () => rcReviews.ShouldAllBe(x => x.FailedIqbs == null || x.FailedIqbs.All(y => y.Status != null)),
                    () => rcReviews.ShouldAllBe(x => x.FailedIqbs == null || x.FailedIqbs.All(y => y.Summary != null))
                    );
            }
        }
    }
}
