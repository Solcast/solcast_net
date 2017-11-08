using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solcast.Types;
using ServiceStack;

namespace Solcast
{
    public static class PowerExtensions
    {
        /// <summary>
        /// Power Estimated Actuals for the location
        /// </summary>
        /// <param name="client"></param>
        /// <param name="location">Location is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <returns></returns>
        public static async Task<GetPvPowerEstimatedActualsResponse> GetPvPowerEstimatedActualsAsync(this SolcastClient client, Location location)
        {
            var reqObj = location.ConvertTo<GetPvPowerEstimatedActuals>().PopulateWithNonDefaultValues(client.System.PowerOptions);
            var result = await client.GetAsync(reqObj);
            return result.Format(client.CurrentTimeZone);
        }        
        
        /// <summary>
        /// [Synchronous] - Power Estimated Actuals for the location
        /// </summary>
        /// <param name="client"></param>
        /// <param name="location">Location is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <returns></returns>
        public static GetPvPowerEstimatedActualsResponse GetPvPowerEstimatedActuals(this SolcastClient client, Location location)
        {
            var reqObj = location.ConvertTo<GetPvPowerEstimatedActuals>().PopulateWithNonDefaultValues(client.System.PowerOptions);
            var result = client.Get(reqObj);
            return result.Format(client.CurrentTimeZone);
        }
        
        /// <summary>
        /// Power Estimated Latest Actuals for the location
        /// </summary>
        /// <param name="client"></param>
        /// <param name="location">Location is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <returns></returns>
        public static async Task<GetPvPowerEstimatedActualsResponse> GetLatestPvPowerEstimatedActualsAsync(this SolcastClient client, Location location)
        {
            var reqObj = location.ConvertTo<GetLatestPvPowerEstimatedActuals>().PopulateWithNonDefaultValues(client.System.PowerOptions);
            var result = await client.GetAsync(reqObj);
            return result.Format(client.CurrentTimeZone);
        }        

        /// <summary>
        /// [Synchronous] - Power Latest Estimated Actuals for the location
        /// </summary>
        /// <param name="client"></param>
        /// <param name="location">Location is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <returns></returns>
        public static GetPvPowerEstimatedActualsResponse GetLatestPvPowerEstimatedActuals(this SolcastClient client, Location location)
        {
            var reqObj = location.ConvertTo<GetLatestPvPowerEstimatedActuals>().PopulateWithNonDefaultValues(client.System.PowerOptions);
            var result = client.Get(reqObj);
            return result.Format(client.CurrentTimeZone);
        }        
        
        /// <summary>
        /// Power Forecasts for the location
        /// </summary>
        /// <param name="client"></param>
        /// <param name="location">Location is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <returns></returns>
        public static async Task<GetPvPowerForecastsResponse> GetPvPowerForecastsAsync(this SolcastClient client, Location location)
        {
            var reqObj = location.ConvertTo<GetPvPowerForecasts>().PopulateWithNonDefaultValues(client.System.PowerOptions);
            var result = await client.GetAsync(reqObj);
            return result.Format(client.CurrentTimeZone);
        }        
        
        /// <summary>
        /// [Synchronous] - Power Forecasts for the location
        /// </summary>
        /// <param name="client"></param>
        /// <param name="location">Location is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <returns></returns>
        public static GetPvPowerForecastsResponse GetPvPowerForecasts(this SolcastClient client, Location location)
        {
            var reqObj = location.ConvertTo<GetPvPowerForecasts>().PopulateWithNonDefaultValues(client.System.PowerOptions);
            var result = client.Get(reqObj);
            return result.Format(client.CurrentTimeZone);
        }        
        
        private static IEnumerable<PvPowerEstimate> FormatTimeZone(this IEnumerable<PvPowerEstimate> results, TimeZoneInfo current)
        {
            foreach (var result in results ?? new List<PvPowerEstimate>())
            {
                result.PeriodEnd = result.PeriodEnd.ConvertTime(current);
            }
            return results;
        }        

        private static GetPvPowerEstimatedActualsResponse Format(this GetPvPowerEstimatedActualsResponse response, TimeZoneInfo current)
        {
            response.EstimatedActuals = response.EstimatedActuals.FormatTimeZone(current).ToList();
            return response;
        }          
        
        private static GetPvPowerForecastsResponse Format(this GetPvPowerForecastsResponse response, TimeZoneInfo current)
        {
            response.Forecasts = response.Forecasts.FormatTimeZone(current).ToList();
            return response;
        }
    }
}