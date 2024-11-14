
using System;
using System.Net.Http;
using System.Reflection;

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

            // Get the version from the assembly metadata for User-Agent
            var version = GetAssemblyVersion();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"solcast-api-csharp-sdk/{version}");
        }

        private static string GetAssemblyVersion()
        {
            var attribute = (AssemblyInformationalVersionAttribute)Attribute.GetCustomAttribute(
                Assembly.GetExecutingAssembly(),
                typeof(AssemblyInformationalVersionAttribute)
            );

            var version = attribute?.InformationalVersion ?? "1.0.0";
            return version.Split('+')[0];
        }
    }
}
