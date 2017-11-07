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
                    if (Debugger.IsAttached)
                    {
                        Debug.WriteLine(request.ToGetUrl());
                        Console.WriteLine(request.ToGetUrl());
                    }                    
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
                    if (Debugger.IsAttached)
                    {
                        Debug.WriteLine(request.ToGetUrl());
                        Console.WriteLine(request.ToGetUrl());
                    }                    
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
                    if (Debugger.IsAttached)
                    {
                        Debug.WriteLine(request.ToGetUrl());
                        Console.WriteLine(request.ToGetUrl());
                    }                    
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
                client.Headers.Add(HttpHeaders.Authorization, $"Bearer {API.Key(apiKey)}");
                if (Debugger.IsAttached)
                {
                    Debug.WriteLine(request.ToGetUrl());
                    Console.WriteLine(request.ToGetUrl());
                }
                var response = await client.GetAsync(request);
                return response;
            }            
        }
        public static async Task<GetRadiationEstimatedActualsResponse> EstimatedActuals(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                var request = position.ToRadiationEstimatedActuals();
                client.Headers.Add(HttpHeaders.Authorization, $"Bearer {API.Key(apiKey)}");
                if (Debugger.IsAttached)
                {
                    Debug.WriteLine(request.ToGetUrl());
                    Console.WriteLine(request.ToGetUrl());
                }
                var response = await client.GetAsync(request);
                return response;
            }              
        }
        public static async Task<GetLatestRadiationEstimatedActualsResponse> LatestEstimatedActuals(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                var request = position.ToLatestRadiationEstimatedActuals();
                client.Headers.Add(HttpHeaders.Authorization, $"Bearer {API.Key(apiKey)}");
                if (Debugger.IsAttached)
                {
                    Debug.WriteLine(request.ToGetUrl());
                    Console.WriteLine(request.ToGetUrl());
                }
                var response = await client.GetAsync(request);
                return response;
            }
        }                
    }
}