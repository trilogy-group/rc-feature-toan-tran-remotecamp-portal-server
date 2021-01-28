using System;
using System.Linq;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Infrastructure.Jira;
using RemoteCamp.Portal.Core.Utils;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.Integration.BusinessLogic.Repositories
{
    public class RcTaskRepositoryTest
    {
        [Fact]
        public async void FindByAssigneeAndOnceSubmittedAsync_TicketsExists_ReturnsTickets()
        {
            var applicationOption = TestApplicationOptionsFactory.Default.Create();
            var repository = new RcTaskJiraRepository(new JiraClientAdapter(applicationOption), applicationOption);

            var tasks = await repository.FindByAssigneeAsync("vitaliy.sedletskiy");

            tasks.ShouldNotBeNull();

            if (tasks.Count > 0)
            {
                this.ShouldSatisfyAllConditions(
                    () => tasks.ShouldAllBe(x => x.Status != null),
                    () => tasks.ShouldAllBe(x => x.JiraKey != null),
                    () => tasks.ShouldAllBe(x => x.Summary != null),
                    () => tasks.ShouldAllBe(x => x.Score.HasValue),
                    () => tasks.ShouldAllBe(x => x.Module != null));
            }
        }

        [Fact]
        public async void FindFailedByAssigneeAndDatesAsync_TicketsExists_ReturnsTickets()
        {
            var applicationOption = TestApplicationOptionsFactory.Default.Create();
            var repository = new RcTaskJiraRepository(new JiraClientAdapter(applicationOption), applicationOption);

            var tasks = await repository.FindFailedByAssigneeAndDatesAsync("vitaliy.sedletskiy", new Range<DateTime>(DateTime.UtcNow.AddMonths(-1), DateTime.UtcNow));

            tasks.ShouldNotBeNull();

            if (tasks.Count > 0)
            {
                this.ShouldSatisfyAllConditions(
                    () => tasks.ShouldAllBe(x => x.Status != null),
                    () => tasks.ShouldAllBe(x => x.JiraKey != null),
                    () => tasks.ShouldAllBe(x => x.Summary != null),
                    () => tasks.ShouldAllBe(x => x.Score.HasValue),
                    () => tasks.ShouldAllBe(x => x.Module != null),
                    () => tasks.ShouldAllBe(x => x.Reviews == null || x.FailedIqbs.All(y => y.JiraKey != null)),
                    () => tasks.ShouldAllBe(x => x.Reviews == null || x.FailedIqbs.All(y => y.Status != null)),
                    () => tasks.ShouldAllBe(x => x.Reviews == null || x.FailedIqbs.All(y => y.Summary != null)),
                    () => tasks.ShouldAllBe(x => x.FailedIqbs == null || x.FailedIqbs.All(y => y.JiraKey != null)),
                    () => tasks.ShouldAllBe(x => x.FailedIqbs == null || x.FailedIqbs.All(y => y.Status != null)),
                    () => tasks.ShouldAllBe(x => x.FailedIqbs == null || x.FailedIqbs.All(y => y.Summary != null))
                    );
            }
        }
    }
}
