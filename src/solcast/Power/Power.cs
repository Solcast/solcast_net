using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
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
            public static async Task<string> Test()
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MimeTypes.Json));
                    using (var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/1"))
                    {
                        response.EnsureSuccessStatusCode();

                        return await response.Content.ReadAsStringAsync(); // here we return the json response, you may parse it
                    }
                }
            }

            public static GetPvPowerForecastsResponse Forecast(Location position, string apiKey = null)
            {



                //var request = position.ToPvPowerForecasts();
                //Debug.WriteLine(request.ToGetUrl());

                //var req = WebRequest.Create($"{API.Url}{request.ToGetUrl()}");
                //req.Headers.Add(HttpHeaders.ContentType, MimeTypes.Json);
                //var resp = req.GetResponse();

                using (var client = new JsonHttpClient(API.Url))
                {
                    //client.Timeout = API.Timeout;
                    //client.Headers.Add(HttpHeaders.Authorization, $"Bearer {API.Key(apiKey)}");
                    //client.Headers.Add(HttpHeaders.ContentType, MimeTypes.Json);
                    var request = position.ToPvPowerForecasts();
                    Debug.WriteLine(request.ToGetUrl());
                    Console.WriteLine(request.ToGetUrl());
                    var response = client.Get(request);
                    return response;
                }            
            }              
        }
        
        public static async Task<GetPvPowerForecastsResponse> Forecast(Location position, string apiKey = null)
        {
            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MimeTypes.Json));
            //        //API.Key(apiKey));

            //    using (var response = await client.GetAsync(url))
            //    {
            //        response.EnsureSuccessStatusCode();
            //        var data = await response.Content.ReadAsStringAsync();
            //        return data.FromJson<GetPvPowerForecastsResponse>();
            //    }
            //}

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