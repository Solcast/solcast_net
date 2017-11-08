using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solcast.Types;
using ServiceStack;

namespace Solcast
{
    public static class RadiationExtensions
    {
        /// <summary>
        ///  Radiation Forecasts for the location
        /// </summary>
        /// <param name="client"></param>
        /// <param name="location">Location is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <returns></returns>
        public static async Task<GetRadiationForecastsResponse> GetRadiationForecastsAsync(this SolcastClient client, Location location)
        {
            var result = await client.GetAsync(location.ConvertTo<GetRadiationForecasts>());
            return result.Format(client.CurrentTimeZone);            
        }        
        
        /// <summary>
        /// [Synchronous] - Radiation Forecasts for the location
        /// </summary>
        /// <param name="client"></param>
        /// <param name="location">Location is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <returns></returns>
        public static GetRadiationForecastsResponse GetRadiationForecasts(this SolcastClient client, Location location)
        {
            var result = client.Get(location.ConvertTo<GetRadiationForecasts>());
            return result.Format(client.CurrentTimeZone);            
        }        
        
        /// <summary>
        /// Radiation Estimated Actuals for the location
        /// </summary>
        /// <param name="client"></param>
        /// <param name="location">Location is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <returns></returns>
        public static async Task<GetRadiationEstimatedActualsResponse> GetRadiationEstimatedActualsAsync(
            this SolcastClient client, Location location)
        {
            var result = await client.GetAsync(location.ConvertTo<GetRadiationEstimatedActuals>());
            return result.Format(client.CurrentTimeZone);
        }

        /// <summary>
        /// [Synchronous] - Radiation Estimated Actuals for the location
        /// </summary>
        /// <param name="client"></param>
        /// <param name="location">Location is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <returns></returns>
        public static GetRadiationEstimatedActualsResponse GetRadiationEstimatedActuals(this SolcastClient client, Location location)
        {
            var result = client.Get(location.ConvertTo<GetRadiationEstimatedActuals>());
            return result.Format(client.CurrentTimeZone);
        }
        
        /// <summary>
        /// Radiation Latest Estimated Actuals for the location
        /// </summary>
        /// <param name="client"></param>
        /// <param name="location">Location is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <returns></returns>
        public static async Task<GetLatestRadiationEstimatedActualsResponse> GetLatestRadiationEstimatedActualsAsync(
            this SolcastClient client, Location location)
        {
            var result = await client.GetAsync(location.ConvertTo<GetLatestRadiationEstimatedActuals>());
            return result.Format(client.CurrentTimeZone);
        }

        /// <summary>
        /// [Synchronous] - Radiation Latest Estimated Actuals for the location
        /// </summary>
        /// <param name="client"></param>
        /// <param name="location">Location is a EPSG 4326 Latitude/Longitude position on the Earth</param>
        /// <returns></returns>
        public static GetLatestRadiationEstimatedActualsResponse GetLatestRadiationEstimatedActuals(this SolcastClient client, Location location)
        {
            var result = client.Get(location.ConvertTo<GetLatestRadiationEstimatedActuals>());
            return result.Format(client.CurrentTimeZone);
        }
                        
        private static GetRadiationEstimatedActualsResponse Format(this GetRadiationEstimatedActualsResponse response, TimeZoneInfo current)
        {
            response.EstimatedActuals = response.EstimatedActuals.FormatTimeZone(current).ToList();
            return response;            
        }
        
        private static GetLatestRadiationEstimatedActualsResponse Format(this GetLatestRadiationEstimatedActualsResponse response, TimeZoneInfo current)
        {
            response.EstimatedActuals = response.EstimatedActuals.FormatTimeZone(current).ToList();
            return response;            
        }        
              
        private static IEnumerable<ApiObservation> FormatTimeZone(this IEnumerable<ApiObservation> results, TimeZoneInfo current)
        {
            foreach (var result in results ?? new List<ApiObservation>())
            {
                result.PeriodEnd = result.PeriodEnd.ConvertTime(current);
            }
            return results;
        }        
        
        private static IEnumerable<ApiRadiationForecast> FormatTimeZone(this IEnumerable<ApiRadiationForecast> results,
            TimeZoneInfo current)
        {
            foreach (var result in results ?? new List<ApiRadiationForecast>())
            {
                result.PeriodEnd = result.PeriodEnd.ConvertTime(current);
            }
            return results;
        }

        private static GetRadiationForecastsResponse Format(this GetRadiationForecastsResponse response,
            TimeZoneInfo current)
        {
            response.Forecasts = response.Forecasts.FormatTimeZone(current).ToList();
            return response;
        }
    }
}