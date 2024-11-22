
using System;
using System.Net.Http;
using System.Reflection;
using System.Net;

namespace Solcast.Clients
{
    public abstract class BaseClient : IDisposable
    {
        private bool _disposed = false;
        protected readonly HttpClient _httpClient;

        protected BaseClient(string baseUrl = null, IWebProxy proxy = null)
        {
            var apiKey = Environment.GetEnvironmentVariable("SOLCAST_API_KEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new MissingApiKeyException("The SOLCAST_API_KEY environment variable is not set.");
            }

            var httpClientHandler = new HttpClientHandler();
            if (proxy != null)
            {
                httpClientHandler.Proxy = proxy;
                httpClientHandler.UseProxy = true;
            }

            _httpClient = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri(baseUrl ?? SolcastUrls.BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            // Get the version from the assembly metadata for User-Agent
            var version = GetAssemblyVersion();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"solcast-api-csharp-sdk/{version}");
        }

        protected void HandleUnauthorizedResponse(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedApiKeyException("The API key provided is invalid or unauthorized.");
            }
            response.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                }
                _disposed = true;
            }
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

    public class MissingApiKeyException : Exception
    {
        public MissingApiKeyException(string message) : base(message) { }
    }

    public class UnauthorizedApiKeyException : Exception
    {
        public UnauthorizedApiKeyException(string message) : base(message) { }
    }
}
