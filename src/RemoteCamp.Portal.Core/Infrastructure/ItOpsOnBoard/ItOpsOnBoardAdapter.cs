using System.Net.Http;
using System.Threading.Tasks;
using RemoteCamp.Portal.Core.Infrastructure.Data;
using Serilog;

namespace RemoteCamp.Portal.Core.Infrastructure.ItOpsOnBoard
{
    public class ItOpsOnBoardAdapter : IItOpsOnBoardAdapter
    {
        private readonly ApplicationOptions _applicationOptions;

        public ItOpsOnBoardAdapter(ApplicationOptions applicationOptions)
        {
            _applicationOptions = applicationOptions;
        }

        public async Task<bool> SendAsync(ItOpsOnBoardRequest itOpsOnBoardRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(_applicationOptions.ItOpsOnBoardRequestUrl, new
                {
                    issue = new
                    {
                        fields = new
                        {
                            customfield_12847 = itOpsOnBoardRequest.Name,
                            customfield_12849 = itOpsOnBoardRequest.Email,
                            customfield_12815 = itOpsOnBoardRequest.Manager,
                            customfield_12854 = new
                            {
                                value = itOpsOnBoardRequest.Pipeline
                            },
                            customfield_12897 = itOpsOnBoardRequest.Application360Link
                        }
                    }
                });

                if (!response.IsSuccessStatusCode)
                {
                    Log.Logger.Warning($"Error occurred while sending ITOps ticket, HTTP code {response.StatusCode}: {response.Content}");
                }

                return response.IsSuccessStatusCode;
            }
        }
    }
}