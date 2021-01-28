using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using RemoteCamp.Portal.Core.Infrastructure.Common;
using RemoteCamp.Portal.Core.Infrastructure.Data;

namespace RemoteCamp.Portal.Core.Infrastructure.Google
{
    // In development
    public class GoogleDirectoryServiceAdapter
    {
        private readonly ApplicationOptions _options;
        private static string[] Scopes = {
            DirectoryService.Scope.AdminDirectoryGroupMemberReadonly,
            DirectoryService.Scope.AdminDirectoryUserReadonly, 
            DirectoryService.Scope.AdminDirectoryGroupReadonly
        };
        private DirectoryService _service;

        public GoogleDirectoryServiceAdapter(ApplicationOptions options)
        {
            _options = options;
        }

        public void Initialize()
        {
            if (_service != null)
            {
                return;
            }

            var initializer = new ServiceAccountCredential.Initializer(_options.GoogleApiEmail)
            {
                    User = _options.GoogleApiEmail,
                    ProjectId = "remotecamp",
                    Scopes = Scopes
            };
            
            initializer.FromPrivateKey(_options.GoogleApiPrivateKey);
            var credential = new ServiceAccountCredential(initializer);

            // Initialize Google Sheets API service.
            _service = new DirectoryService(
                new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = InfrastructureConstants.ApplicationName,
                });
        }

        public DirectoryService GetService()
        {
            return _service;
        }
    }
}