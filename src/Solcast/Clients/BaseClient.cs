
using System;
using System.Net.Http;

namespace Solcast.Clients
{
    public abstract class BaseClient
    {
        protected readonly HttpClient _httpClient;

        protected BaseClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(SolcastUrls.BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("SOLCAST_API_KEY")}");
        }
    }
}
