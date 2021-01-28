using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using RemoteCamp.Portal.Core.Infrastructure.Data;
using RemoteCamp.Portal.Core.Utils;

namespace RemoteCamp.Portal.Core.Infrastructure.Google
{
    public class GoogleSheetServiceAdapter : IGoogleSheetServiceAdapter
    {
        private readonly ApplicationOptions _options;
        private static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        private static string ApplicationName = "Google Sheets API .NET Quickstart";

        private SheetsService _service;

        public GoogleSheetServiceAdapter(ApplicationOptions options)
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
                Scopes = Scopes
            };
            
            initializer.FromPrivateKey(_options.GoogleApiPrivateKey);
            var credential = new ServiceAccountCredential(initializer);

            // Initialize Google Sheets API service.
            _service = new SheetsService(
                new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
        }

        public IList<IList<object>> GetValues(string spreadsheetId, string range)
        {
            return AsyncUtil.RunSync(() => GetValuesAsync(spreadsheetId, range));
        }

        public async Task<IList<IList<object>>> GetValuesAsync(string spreadsheetId, string range)
        {
            if (_service == null)
            {
                throw new InvalidOperationException("The instance is not initialized");
            }

            var request = _service.Spreadsheets.Values.Get(spreadsheetId, range);
            var response = await request.ExecuteAsync();
            return response.Values;
        }
    }
}