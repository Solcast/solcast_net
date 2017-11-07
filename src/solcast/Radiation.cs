using System.Threading.Tasks;
using solcast.types;
using ServiceStack;

namespace solcast
{
    public static partial class Radiation
    {

        /// <summary>
        /// Solcast Power Radiation for the position
        /// </summary>
        /// <param name="position">Position is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <param name="apiKey">API Key override to use instead of environment variable *SOLCAST_API_KEY*</param>
        /// <returns></returns> 
        public static async Task<GetRadiationForecastsResponse> Forecast(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                client.DefaultSolcastClient(API.Key(apiKey));
                var request = position.ToRadiationForecasts();                
                var response = await client.GetAsync(request);
                return response;
            }            
        }
        /// <summary>
        /// Solcast Radiation Estimated Actuals for the position
        /// </summary>
        /// <param name="position">Position is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <param name="apiKey">API Key override to use instead of environment variable *SOLCAST_API_KEY*</param>
        /// <returns></returns>  
        public static async Task<GetRadiationEstimatedActualsResponse> EstimatedActuals(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                client.DefaultSolcastClient(API.Key(apiKey));
                var request = position.ToRadiationEstimatedActuals();                
                var response = await client.GetAsync(request);
                return response;
            }              
        }
        /// <summary>
        /// Solcast Radiation Latest Estimated Actuals for the position
        /// </summary>
        /// <param name="position">Position is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <param name="apiKey">API Key override to use instead of environment variable *SOLCAST_API_KEY*</param>
        /// <returns></returns>   
        public static async Task<GetLatestRadiationEstimatedActualsResponse> LatestEstimatedActuals(Location position, string apiKey = null)
        {
            using (var client = new JsonHttpClient(API.Url))
            {
                client.DefaultSolcastClient(API.Key(apiKey));
                var request = position.ToLatestRadiationEstimatedActuals();                
                var response = await client.GetAsync(request);
                return response;
            }
        }                
    }
}