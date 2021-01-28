using RemoteCamp.Portal.Core.Infrastructure.Data;

namespace RemoteCamp.Portal.Core.Test.Integration
{
    public class TestApplicationOptionsFactory 
    {
        public static TestApplicationOptionsFactory Default { get; } = new TestApplicationOptionsFactory();

        public ApplicationOptions Create()
        {
            // Provide own credentials
            return new ApplicationOptions
            {
                IsProductionMode = false,
                XoJiraUserName = "remotecamp-qe@trilogy.com",
                XoJiraPassword = "17ve8UXTXBjIlqClc2uo4B84",
                JiraSettings = new ApplicationOptions.JiraSetting
                {
                    IcCardProject = "ER"
                },
                GoogleApiEmail = string.Empty,
                GoogleApiPrivateKey = string.Empty,
                GithubAccessToken = string.Empty,
            };
        }
    }
}
