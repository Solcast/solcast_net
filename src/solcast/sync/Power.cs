using solcast.types;
using ServiceStack;

namespace solcast.sync
{
    /// <summary>
    /// All methods in this class are synchronous
    /// </summary>
    public static class Power
    {
        /// <summary>
        /// [Synchronous] - Solcast Power Forecast for the position
        /// </summary>
        /// <param name="position">Position is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <param name="apiKey">API Key override to use instead of environment variable *SOLCAST_API_KEY*</param>
        /// <returns></returns>
        public static GetPvPowerForecastsResponse Forecast(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                var request = position.ToPowerForecasts();
                client.DefaultSolcastClient(API.Key(apiKey));
                var response = client.Get(request);
                return response;
            }
        }

        /// <summary>
        /// [Synchronous] - Solcast Power Estimated Actuals for the position
        /// </summary>
        /// <param name="position">Position is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <param name="apiKey">API Key override to use instead of environment variable *SOLCAST_API_KEY*</param>
        /// <returns></returns>            
        public static GetPvPowerEstimatedActualsResponse EstimatedActuals(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                client.DefaultSolcastClient(API.Key(apiKey));
                var request = position.ToPowerEstimatedActuals();
                var response = client.Get(request);
                return response;
            }
        }

        /// <summary>
        /// [Synchronous] - Solcast Power Latest Estimated Actuals for the position
        /// </summary>
        /// <param name="position">Position is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <param name="apiKey">API Key override to use instead of environment variable *SOLCAST_API_KEY*</param>
        /// <returns></returns>            
        public static GetPvPowerEstimatedActualsResponse LatestEstimatedActuals(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                client.DefaultSolcastClient(API.Key(apiKey));
                var request = position.ToLatestPowerEstimatedActuals();
                var response = client.Get(request);
                return response;
            }
        }
    }
}