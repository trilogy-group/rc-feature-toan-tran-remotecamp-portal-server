using System;
using System.Collections.Generic;
using RestSharp;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCamp.Portal.Core.Infrastructure.Crossover
{
    public interface ICrossoverClient
    {
        void Initialize();

        Task<string> GetAsync(string url, List<Parameter> parameters = null);
    }
}
