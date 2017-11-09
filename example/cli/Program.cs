using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack;
using Solcast;
using Solcast.ServiceModel;

namespace Cli
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
            
            try
            {
                Console.WriteLine($"Solcast_API_KEY = {API.Key()}");
                Console.Write($"Current API timeout setting = {API.Timeout}");

                // Single request
                var syncResponse = PowerForecast(location);
                syncResponse.Validate().ToConsole();
                
                // Sequential requests
                PrintBatch(PowerForecasts(locations).ToList().Select(z => z.Validate()));
                                
                // Batched requests
                BatchedPowerForecasts(locations);
                PrintBatch(BatchedPowerForecasts(locations));

                // Async single request
                Task.Run(async () =>
                {
                    var result = await PowerForecastAsync(location);
                    result.Validate().ToConsole();
                }).Wait();
            }
            catch (Exception e)
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
                Console.WriteLine(e);
            }
        }

        private static void PrintBatch(IEnumerable<GetPvPowerForecastsResponse> responses)
        {
            foreach (var response in responses)
            {
                response.ToConsole();                    
            }            
        }

        private static IEnumerable<GetPvPowerForecastsResponse> BatchedPowerForecasts(IEnumerable<Location> locations)
        {
            using (var client = new SolcastClient())
            {
                var requests = locations.Select(z =>
                    z.ConvertTo<GetPvPowerForecasts>().PopulateWithNonDefaultValues(client.System.PowerOptions));
                return client.SendAll(requests);
            }
        }         
        
        private static IEnumerable<GetPvPowerForecastsResponse> PowerForecasts(IEnumerable<Location> locations)
        {
            using (var client = new SolcastClient())
            {
                return locations.Select(location => client.GetPvPowerForecasts(location)).ToList();
            }
        }        
        
        private static GetPvPowerForecastsResponse PowerForecast(Location location)
        {
            using (var client = new SolcastClient())
            {
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
