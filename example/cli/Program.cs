using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Solcast.Types;
using Solcast;

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
            try
            {
                Console.WriteLine($"Solcast_API_KEY = {API.Key()}");
                Console.Write($"Current API timeout setting = {API.Timeout}");

                var syncResponse = PowerForecast(location);                
                syncResponse.Validate().ToConsole();                

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
