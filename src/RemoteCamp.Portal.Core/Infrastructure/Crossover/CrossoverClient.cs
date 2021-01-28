using RemoteCamp.Portal.Core.Infrastructure.Data;
using RestSharp;
using RestSharp.Authenticators;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteCamp.Portal.Core.Infrastructure.Crossover
{
    public class CrossoverClient : ICrossoverClient
    {
        private const string DefaultCrossoverApiUrl = "https://api.crossover.com/api";
        private readonly ApplicationOptions _options;
        private RestClient Client { get; set; }

        public CrossoverClient(ApplicationOptions options)
        {
            _options = options;
        }

        public void Initialize()
        {
            Client = new RestClient(DefaultCrossoverApiUrl)
            {
                Authenticator = new HttpBasicAuthenticator(_options.CrossoverUserName, _options.CrossoverPassword),
            };
        }

        public async Task<string> GetAsync(string url, List<Parameter> parameters = null)
        {
            var request = new RestRequest($"{DefaultCrossoverApiUrl}/{url}", Method.GET);
            request.RequestFormat = DataFormat.Json;
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    request.AddParameter(item.Name, item.Value, item.Type);
                }
            }
            var response = await Client.ExecuteTaskAsync(request);
            if (response.ErrorException != null)
            {
                Log.Logger.Error(response.ErrorException, string.Empty);
                throw response.ErrorException;
            }
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Log.Logger.Error(response.ErrorMessage);
                throw new ArgumentNullException(response.ErrorMessage);
            }
            return response.Content;
        }

    }
}
