using System;
using System.Threading.Tasks;
using Solcast.Clients;

namespace Solcast.Examples
{
    public class AggregationExample
    {
        public static async Task RunAggregationExample()
        {
            try
            {
                var aggregationClient = new AggregationClient();

                // // Example for Live Aggregation
                // var response = await aggregationClient.GetLiveAggregations(
                //     collectionId: "country_total",
                //     aggregationId: "it_total", 
                //     outputParameters: ["percentage", "pv_estimate"],
                //     format: "csv"
                // );
                // Console.WriteLine("Live Aggregation Data:");
                // Console.WriteLine(response.RawResponse);

                // Example for Forecast Aggregation
                var response = await aggregationClient.GetForecastAggregations(
                    collectionId: "country_total",
                    aggregationId: "it_total",
                    outputParameters: ["percentage", "pv_estimate"],
                    format: "csv"
                );
                Console.WriteLine("Forecast Aggregation Data:");
                Console.WriteLine(response.RawResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AggregationExample: {ex.Message}");
            }
        }
    }
}
