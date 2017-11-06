using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using solcast.types;
using ServiceStack;

namespace solcast
{
    public static class Radiation
    {
        public static class Sync
        {
            public static GetRadiationForecastsResponse Forecast(Location position, string apiKey = null)
            {
                using (var client = new JsonServiceClient(API.Url))
                {
                    client.Timeout = API.Timeout;
                    //client.Headers.Add(HttpHeaders.Authorization, $"Bearer {API.Key(apiKey)}");
                    client.Headers.Add(HttpHeaders.ContentType, MimeTypes.Json);
                    var request = position.ToRadiationForecasts();
                    Debug.WriteLine(request.ToGetUrl());
                    var response = client.Get(request);
                    return response;
                }            
            }              
        }

        public static async Task<GetRadiationForecastsResponse> Forecast(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                var request = position.ToRadiationForecasts();
                client.BearerToken = API.Key(apiKey);
                Debug.WriteLine(request.ToGetUrl());
                var response = await client.GetAsync(request);
                return response;
            }            
        }          
    }
}