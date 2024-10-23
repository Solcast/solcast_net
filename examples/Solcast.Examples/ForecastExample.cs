using Solcast.Clients;

namespace Solcast.Examples
{
    public class ForecastExample
    {
        public static async Task RunForecastExample()
        {
            try
            {
                var forecastClient = new ForecastClient();
                double latitude = -33.856784;
                double longitude = 151.215297;
                List<string> outputParameters = ["dni", "ghi", "air_temp"];
                string format = "csv";

                var response = await forecastClient.GetRadiationAndWeather(
                    latitude: latitude,
                    longitude: longitude,
                    outputParameters: outputParameters,
                    format: format
                );

                Console.WriteLine("Forecast Radiation and Weather Data (CSV):");
                Console.WriteLine(response.RawResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ForecastExample: {ex.Message}");
            }
        }
    }
}
