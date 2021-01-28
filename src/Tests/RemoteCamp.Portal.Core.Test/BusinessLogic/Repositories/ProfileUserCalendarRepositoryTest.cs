using System.Threading.Tasks;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.Database;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Test.Helpers;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Repositories
{
    public class ProfileUserCalendarRepositoryTest
    {
        private readonly ProfileUserCalendarItemStatusRepository _profileUserCalendarItemStatusRepository;
        private readonly RemoteCampContext _context;

        public ProfileUserCalendarRepositoryTest()
        {
            _context = ContextFactory.CreateContext(true);
            _profileUserCalendarItemStatusRepository = new ProfileUserCalendarItemStatusRepository(_context);
        }

        [Fact]
        public async Task GetAllAsync_UserCalendarItemExist_ReturnsUserCalendarItemsObject()
        {
            // Arrange ,Act
            var result = await _profileUserCalendarItemStatusRepository.GetAllAsync(1, CalendarType.EngRemoteU);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Count.ShouldBe(130));
        }
    }
}
