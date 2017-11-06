using System;
using System.Diagnostics;
using System.Threading.Tasks;
using solcast.types;
using ServiceStack;
using HttpHeaders = ServiceStack.HttpHeaders;

namespace solcast
{
    public static class Power
    {
        public static class Sync
        {
            public static GetPvPowerForecastsResponse Forecast(Location position, string apiKey = null)
            {
                using (var client = new JsonHttpClient(API.Url))
                {
                    var request = position.ToPvPowerForecasts();
                    client.Headers.Add(HttpHeaders.Authorization, $"Bearer {API.Key(apiKey)}");
                    Debug.WriteLine(request.ToGetUrl());
                    Console.WriteLine(request.ToGetUrl());
                    var response = client.Get(request);
                    return response;
                }            
            }              
        }
        
        public static async Task<GetPvPowerForecastsResponse> Forecast(Location position, string apiKey = null)
        {
            using (var client = new JsonServiceClient(API.Url))
            {
                client.Timeout = API.Timeout;
                client.Headers.Add(HttpHeaders.Authorization, $"Bearer {API.Key(apiKey)}");
                var request = position.ToPvPowerForecasts();
                var response = await client.GetAsync(request);
                return response;
            }
        }
    }
}