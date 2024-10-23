using System;
using System.Threading.Tasks;
using Solcast.Clients;

namespace Solcast.Examples
{
    public class LiveExample
    {
        public static async Task RunLiveExample()
        {
            try
            {
                var liveClient = new LiveClient();
                var response = await liveClient.GetRadiationAndWeather(
                    latitude: -33.856784,
                    longitude: 151.215297,
                    outputParameters: ["dni", "ghi", "air_temp"],
                    format: "csv"
                );

                Console.WriteLine("Live Radiation and Weather Data (CSV):");
                Console.WriteLine(response.RawResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LiveExample: {ex.Message}");
            }
        }
    }
}
