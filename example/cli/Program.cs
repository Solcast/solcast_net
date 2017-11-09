using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Polly;
using ServiceStack;
using Solcast;
using Solcast.ServiceModel;

namespace Cli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, eventArgs) =>
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
                Console.WriteLine(eventArgs);
            };

            var location = new Location
            {
                Latitude = 32,
                Longitude = -97
            };

            var locations = new List<Location>
            {
                new Location { Latitude = 32, Longitude = -97},
                new Location { Latitude = 32, Longitude = -98},
                new Location { Latitude = 32, Longitude = -99},
                new Location { Latitude = 32, Longitude = -100}
            };                
            
            Console.WriteLine($"Solcast_API_KEY = {API.Key()}");
            Console.Write($"Current API timeout setting = {API.Timeout}");

            // Single request
            var syncResponse = PowerForecast(location);
            syncResponse.Validate().ToConsole();

            // Single request with Wait Retry Policy
            var waitRetrySyncResponse = WaitRetryPowerForecast(location);
            waitRetrySyncResponse.Validate().ToConsole();

            // Sequential requests
            PowerForecasts(locations).ToList().Select(z => z.Validate()).Print();

            // Batched requests
            BatchedPowerForecasts(locations).Print();

            // Async single request
            Task.Run(async () =>
            {
                var result = await PowerForecastAsync(location);
                result.Validate().ToConsole();
            }).Wait();
        }

        private static IEnumerable<GetPvPowerForecastsResponse> BatchedPowerForecasts(IEnumerable<Location> locations)
        {
            var results = new List<GetPvPowerForecastsResponse>();
            using (var client = new SolcastClient())
            {
                Parallel.ForEach(locations, location =>
                {
                    results.Add(client.GetPvPowerForecasts(location));
                });                
            }
            return results;
        }
        
        private static IEnumerable<GetPvPowerForecastsResponse> PowerForecasts(IEnumerable<Location> locations)
        {
            using (var client = new SolcastClient())
            {
                return locations.Select(location => client.GetPvPowerForecasts(location)).ToList();
            }
        }

        private static GetPvPowerForecastsResponse WaitRetryPowerForecast(Location location)
        {
            // Set a policy on WebServiceExceptions with StatusCode of 429 to wait and retry the request again in 5 seconds
            var policy = Policy
                .Handle<WebServiceException>(z => z.StatusCode == 429)
                .WaitAndRetry(new[] { TimeSpan.FromSeconds(5) });

            return policy.Execute(() =>
            {
                using (var client = new SolcastClient())
                {
                    return client.GetPvPowerForecasts(location);
                }
            });
        }

        private static GetPvPowerForecastsResponse PowerForecast(Location location)
        {
            using (var client = new SolcastClient())
            {
                client.RateLimitExceededFn = message =>
                {
                    // Custom Action code to place if RateLimit has been exceeded
                };
                return client.GetPvPowerForecasts(location);
            }
        }

        private static async Task<GetPvPowerForecastsResponse> PowerForecastAsync(Location location)
        {
            using (var client = new SolcastClient())
            {
                return await client.GetPvPowerForecastsAsync(location);
            }
        }
    }
}
