using System.Threading.Tasks;
using Solcast.Types;
using ServiceStack;

namespace Solcast
{
    public static class Power
    {
        /// <summary>
        /// [Synchronous] - Solcast Power Forecast for the position
        /// </summary>
        /// <param name="position">Position is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <param name="apiKey">API Key override to use instead of environment variable *Solcast_API_KEY*</param>
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
        /// <param name="apiKey">API Key override to use instead of environment variable *Solcast_API_KEY*</param>
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
        /// <param name="apiKey">API Key override to use instead of environment variable *Solcast_API_KEY*</param>
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
        /// <summary>
        /// Solcast Power Forecast for the position
        /// </summary>
        /// <param name="position">Position is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <param name="apiKey">API Key override to use instead of environment variable *Solcast_API_KEY*</param>
        /// <returns></returns>        
        public static async Task<GetPvPowerForecastsResponse> ForecastAsync(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                client.DefaultSolcastClient(API.Key(apiKey));
                var request = position.ToPowerForecasts();             
                var response = await client.GetAsync(request);
                return response;
            }
        }
        /// <summary>
        /// Solcast Power Estimated Actuals for the position
        /// </summary>
        /// <param name="position">Position is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <param name="apiKey">API Key override to use instead of environment variable *Solcast_API_KEY*</param>
        /// <returns></returns>         
        public static async Task<GetPvPowerEstimatedActualsResponse> EstimatedActualsAsync(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                client.DefaultSolcastClient(API.Key(apiKey));
                var request = position.ToPowerEstimatedActuals();                
                var response = await client.GetAsync(request);
                return response;
            }              
        }
        /// <summary>
        /// Solcast Power Latest Estimated Actuals for the position
        /// </summary>
        /// <param name="position">Position is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <param name="apiKey">API Key override to use instead of environment variable *Solcast_API_KEY*</param>
        /// <returns></returns>       
        public static async Task<GetPvPowerEstimatedActualsResponse> LatestEstimatedActualsAsync(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                client.DefaultSolcastClient(API.Key(apiKey));
                var request = position.ToLatestPowerEstimatedActuals();                
                var response = await client.GetAsync(request);
                return response;
            }
        }          
    }
}