using RemoteCamp.Portal.Core.Infrastructure.Google;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.Integration.Infrastructure.Google
{
    public class GoogleDirectoryServiceAdapterTest
    {
        [Fact(Skip = "In Development")]
        public void GetGroups()
        {
            var service = new GoogleDirectoryServiceAdapter(TestApplicationOptionsFactory.Default.Create());
            service.Initialize();
            var gService = service.GetService();
            var membersRequest = gService.Members.List("remotecamp@trilogy.com");
            var members = membersRequest.Execute();
        }
    }
}
