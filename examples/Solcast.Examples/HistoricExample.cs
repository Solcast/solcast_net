using System;
using System.Threading.Tasks;
using Solcast.Clients;

namespace Solcast.Examples
{
    public class HistoricExample
    {
        public static async Task RunHistoricExample()
        {
            var historicClient = new HistoricClient();

            double latitude = -33.856784;
            double longitude = 151.215297;
            string start = "2022-06-01T06:00";
            string duration = "P1D";
            string format = "csv";

            try
            {
                var response = await historicClient.GetRadiationAndWeather(
                    latitude: latitude,
                    longitude: longitude,
                    start: start,
                    duration: duration,
                    format: format
                );

                Console.WriteLine("Historic Radiation and Weather (CSV):");
                Console.WriteLine(response.RawResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in HistoricExample: {ex.Message}");
            }
        }
    }
}
