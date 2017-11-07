using solcast.types;
using ServiceStack;

namespace solcast.sync
{
    /// <summary>
    /// All methods in this class are synchronous
    /// </summary>
    public static class Radiation
    {
        /// <summary>
        /// [Synchronous] - Solcast Radiation Forecast for the position
        /// </summary>
        /// <param name="position">Position is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <param name="apiKey">API Key override to use instead of environment variable *SOLCAST_API_KEY*</param>
        /// <returns></returns>
        public static GetRadiationForecastsResponse Forecast(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                client.DefaultSolcastClient(API.Key(apiKey));
                var request = position.ToRadiationForecasts();
                var response = client.Get(request);
                return response;
            }
        }

        /// <summary>
        /// [Synchronous] - Solcast Radiation Estimated Actuals for the position
        /// </summary>
        /// <param name="position">Position is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <param name="apiKey">API Key override to use instead of environment variable *SOLCAST_API_KEY*</param>
        /// <returns></returns>   
        public static GetRadiationEstimatedActualsResponse EstimatedActuals(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                client.DefaultSolcastClient(API.Key(apiKey));
                var request = position.ToRadiationEstimatedActuals();
                var response = client.Get(request);
                return response;
            }
        }

        /// <summary>
        /// [Synchronous] - Solcast Radiation Latest Estimated Actuals for the position
        /// </summary>
        /// <param name="position">Position is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <param name="apiKey">API Key override to use instead of environment variable *SOLCAST_API_KEY*</param>
        /// <returns></returns>   
        public static GetLatestRadiationEstimatedActualsResponse LatestEstimatedActuals(Location position,
            string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                client.DefaultSolcastClient(API.Key(apiKey));
                var request = position.ToLatestRadiationEstimatedActuals();
                var response = client.Get(request);
                return response;
            }
        }
    }
}