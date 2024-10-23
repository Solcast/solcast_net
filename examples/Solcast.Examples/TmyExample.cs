using System;
using System.Threading.Tasks;
using Solcast.Clients;

namespace Solcast.Examples
{
    public class TmyExample
    {
        public static async Task RunTmyExample()
        {
            try
            {
                var tmyClient = new TmyClient();

                // // Example for Rooftop PV Power data
                // var pvPowerResponse = await tmyClient.GetRooftopPvPower(
                //     latitude: -33.856784,
                //     longitude: 151.215297,
                //     format: "csv",
                //     capacity: 3
                // );
                // Console.WriteLine("TMY Rooftop PV Power Data:");
                // Console.WriteLine(pvPowerResponse.RawResponse);

                // Example for Radiation and Weather data
                var radiationResponse = await tmyClient.GetRadiationAndWeather(
                    latitude: -33.856784,
                    longitude: 151.215297,
                    format: "csv"
                );
                Console.WriteLine("TMY Radiation and Weather Data:");
                Console.WriteLine(radiationResponse.RawResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in TmyExample: {ex.Message}");
            }
        }
    }
}
