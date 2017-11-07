using System;
using System.Diagnostics;
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
                    client.Headers.Add(HttpHeaders.Authorization, $"Bearer {API.Key(apiKey)}");
                    var request = position.ToRadiationForecasts();         
                    var response = client.Get(request);
                    return response;
                }            
            }
            public static GetRadiationEstimatedActualsResponse EstimatedActuals(Location position, string apiKey = null)
            {
                using (var client = new JsonServiceClient(API.Url))
                {
                    client.Timeout = API.Timeout;
                    client.Headers.Add(HttpHeaders.Authorization, $"Bearer {API.Key(apiKey)}");
                    var request = position.ToRadiationEstimatedActuals();               
                    var response = client.Get(request);
                    return response;
                }            
            }
            public static GetLatestRadiationEstimatedActualsResponse LatestEstimatedActuals(Location position, string apiKey = null)
            {
                using (var client = new JsonServiceClient(API.Url))
                {
                    client.Timeout = API.Timeout;
                    client.Headers.Add(HttpHeaders.Authorization, $"Bearer {API.Key(apiKey)}");
                    var request = position.ToLatestRadiationEstimatedActuals();              
                    var response = client.Get(request);
                    return response;
                }            
            }            
        }

        public static async Task<GetRadiationForecastsResponse> Forecast(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                client.Headers.Add(HttpHeaders.Authorization, $"Bearer {API.Key(apiKey)}");
                var request = position.ToRadiationForecasts();                
                var response = await client.GetAsync(request);
                return response;
            }            
        }
        public static async Task<GetRadiationEstimatedActualsResponse> EstimatedActuals(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                client.Headers.Add(HttpHeaders.Authorization, $"Bearer {API.Key(apiKey)}");
                var request = position.ToRadiationEstimatedActuals();                
                var response = await client.GetAsync(request);
                return response;
            }              
        }
        public static async Task<GetLatestRadiationEstimatedActualsResponse> LatestEstimatedActuals(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                client.Headers.Add(HttpHeaders.Authorization, $"Bearer {API.Key(apiKey)}");
                var request = position.ToLatestRadiationEstimatedActuals();                
                var response = await client.GetAsync(request);
                return response;
            }
        }                
    }
}