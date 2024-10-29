
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Solcast.Utilities;

namespace Solcast.Clients
{
    public class HistoricClient : BaseClient
    {
        public HistoricClient()
        {
        }

        /// <param name="start">ISO_8601 compliant starting datetime for the historical data. If the supplied value does not specify a timezone, the timezone will be inferred from the time_zone parameter, if supplied. Otherwise UTC is assumed.</param>
        /// <param name="end">Must include one of end_date and duration. ISO_8601 compliant ending datetime for the historical data. Must be within 31 days of the start_date. If the supplied value does not specify a timezone, the timezone will be inferred from the time_zone parameter, if supplied. Otherwise UTC is assumed.</param>
        /// <param name="duration">Must include one of end_date and duration. ISO_8601 compliant duration for the historical data. Must be within 31 days of the start_date.</param>
        /// <param name="timeZone">Timezone to return in data set. Accepted values are utc, longitudinal, or a range from -13 to 13 in 0.25 hour increments for utc offset.</param>
        /// <param name="outputParameters">The output parameters to include in the response.</param>
        /// <param name="resourceId">The resource id of the resource.</param>
        /// <param name="period">Length of the averaging period in ISO 8601 format.</param>
        /// <param name="hours">The number of hours to return in the response.</param>
        /// <param name="applyAvailability">Percentage of the site’s total AC (inverter) capacity that is currently generating or expected to be generating during the forecast request period. E.g. if you specify a 50% availability, your returned power will be half of what it otherwise would be.</param>
        /// <param name="applyConstraint">Constraint on site’s total AC production, applied as a cap in the same way as the metadata parameter Site Export Limit. This will constrain all Solcast power values to be no higher than the apply_constraint value you specify. If you need an unconstrained forecast, you should not use this parameter.</param>
        /// <param name="applyDustSoiling">A user-override for dust_soiling_average. If you specify this parameter in your API call, we will replace the site's annual or monthly average dust soiling values with the value you specify in your API call.E.g. if you specify a 0.7 dust soiling, your returned power will be reduced by 70%.</param>
        /// <param name="applySnowSoiling">A user-override for Solcast’s dynamic snow soiling, which is based on global snow cover and weather forecast data, and changes from hour to hour. If you specify this parameter in your API call (e.g. if snow clearing has just been performed), we will replace the Solcast dynamic hour to hour value with the single value you specify. E.g. if you specify a 0.7 snow soiling, your returned power will be reduced by 70%.</param>
        /// <param name="applyTrackerInactive">Indicating if trackers are inactive. If True, panels are assumed all facing up (i.e. zero rotation). Only has effect if your site has a tracking_type that is not “fixed”.</param>
        /// <param name="terrainShading">If true, irradiance parameters are modified based on the surrounding terrain from a 90m-horizontal-resolution digital elevation model. The direct component of irradiance is set to zero when the beam from the sun is blocked by the terrain. The diffuse component of irradiance is reduced throughout the day if the sky view at the location is significantly reduced by the surrounding terrain. Global irradiance incorporates both effects.</param>
        /// <param name="format">Response format</param>
        public async Task<ApiResponse<LiveResponse>> GetAdvancedPvPower(
            string start,
            string resourceId,
            string end = null,
            string duration = null,
            string timeZone = null,
            List<string> outputParameters = null,
            string period = null,
            int? hours = null,
            double? applyAvailability = null,
            double? applyConstraint = null,
            double? applyDustSoiling = null,
            double? applySnowSoiling = null,
            bool? applyTrackerInactive = null,
            bool? terrainShading = null,
            string format = null
        )
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("start", start.ToString());
            parameters.Add("resourceId", resourceId.ToString());
            if (end != null) parameters.Add("end", end.ToString());
            if (duration != null) parameters.Add("duration", duration.ToString());
            if (timeZone != null) parameters.Add("timeZone", timeZone.ToString());
            if (outputParameters != null && outputParameters.Any()) parameters.Add("outputParameters", string.Join(",", outputParameters));
            if (period != null) parameters.Add("period", period.ToString());
            if (hours.HasValue) parameters.Add("hours", hours.Value.ToString());
            if (applyAvailability.HasValue) parameters.Add("applyAvailability", applyAvailability.Value.ToString());
            if (applyConstraint.HasValue) parameters.Add("applyConstraint", applyConstraint.Value.ToString());
            if (applyDustSoiling.HasValue) parameters.Add("applyDustSoiling", applyDustSoiling.Value.ToString());
            if (applySnowSoiling.HasValue) parameters.Add("applySnowSoiling", applySnowSoiling.Value.ToString());
            if (applyTrackerInactive.HasValue) parameters.Add("applyTrackerInactive", applyTrackerInactive.Value.ToString());
            if (terrainShading.HasValue) parameters.Add("terrainShading", terrainShading.Value.ToString());
            if (format != null) parameters.Add("format", format.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.HistoricAdvancedPvPower + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<LiveResponse>(rawContent);
                return new ApiResponse<LiveResponse>(data, rawContent);
            }
            return new ApiResponse<LiveResponse>(null, rawContent);
        }

        /// <param name="start">ISO_8601 compliant starting datetime for the historical data. If the supplied value does not specify a timezone, the timezone will be inferred from the time_zone parameter, if supplied. Otherwise UTC is assumed.</param>
        /// <param name="end">Must include one of end_date and duration. ISO_8601 compliant ending datetime for the historical data. Must be within 31 days of the start_date. If the supplied value does not specify a timezone, the timezone will be inferred from the time_zone parameter, if supplied. Otherwise UTC is assumed.</param>
        /// <param name="duration">Must include one of end_date and duration. ISO_8601 compliant duration for the historical data. Must be within 31 days of the start_date.</param>
        /// <param name="timeZone">Timezone to return in data set. Accepted values are utc, longitudinal, or a range from -13 to 13 in 0.25 hour increments for utc offset.</param>
        /// <param name="period">Length of the averaging period in ISO 8601 format.</param>
        /// <param name="tilt">The angle (degrees) that the PV system is tilted off the horizontal. A tilt of 0 means the system faces directly upwards, and 90 means the system is vertical and facing the horizon. If you don't specify tilt, we use a default tilt angle based on the latitude you specify in your request. Must be between 0 and 90.</param>
        /// <param name="azimuth">The azimuth is defined as the angle (degrees) from true north that the PV system is facing. An azimuth of 0 means the system is facing true north. Positive values are anticlockwise, so azimuth is -90 for an east-facing system and 135 for a southwest-facing system. If you don't specify an azimuth, we use a default value of 0 (north facing) in the southern hemisphere and 180 (south-facing) in the northern hemisphere.</param>
        /// <param name="arrayType">The type of sun-tracking or geometry configuration of your site's modules.</param>
        /// <param name="outputParameters">The output parameters to include in the response.</param>
        /// <param name="terrainShading">If true, irradiance parameters are modified based on the surrounding terrain from a 90m-horizontal-resolution digital elevation model. The direct component of irradiance is set to zero when the beam from the sun is blocked by the terrain. The diffuse component of irradiance is reduced throughout the day if the sky view at the location is significantly reduced by the surrounding terrain. Global irradiance incorporates both effects.</param>
        /// <param name="latitude">The latitude of the location you request data for. Must be a decimal number between -90 and 90.</param>
        /// <param name="longitude">The longitude of the location you request data for. Must be a decimal number between -180 and 180.</param>
        /// <param name="hours">The number of hours to return in the response.</param>
        /// <param name="format">Response format</param>
        public async Task<ApiResponse<HistoricRadiationAndWeatherResponse>> GetRadiationAndWeather(
            string start,
            double? latitude,
            double? longitude,
            string end = null,
            string duration = null,
            string timeZone = null,
            string period = null,
            float? tilt = null,
            float? azimuth = null,
            string arrayType = null,
            List<string> outputParameters = null,
            bool? terrainShading = null,
            int? hours = null,
            string format = null
        )
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("start", start.ToString());
            parameters.Add("latitude", latitude.ToString());
            parameters.Add("longitude", longitude.ToString());
            if (end != null) parameters.Add("end", end.ToString());
            if (duration != null) parameters.Add("duration", duration.ToString());
            if (timeZone != null) parameters.Add("timeZone", timeZone.ToString());
            if (period != null) parameters.Add("period", period.ToString());
            if (tilt.HasValue) parameters.Add("tilt", tilt.Value.ToString());
            if (azimuth.HasValue) parameters.Add("azimuth", azimuth.Value.ToString());
            if (arrayType != null) parameters.Add("arrayType", arrayType.ToString());
            if (outputParameters != null && outputParameters.Any()) parameters.Add("outputParameters", string.Join(",", outputParameters));
            if (terrainShading.HasValue) parameters.Add("terrainShading", terrainShading.Value.ToString());
            if (hours.HasValue) parameters.Add("hours", hours.Value.ToString());
            if (format != null) parameters.Add("format", format.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.HistoricRadiationAndWeather + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<HistoricRadiationAndWeatherResponse>(rawContent);
                return new ApiResponse<HistoricRadiationAndWeatherResponse>(data, rawContent);
            }
            return new ApiResponse<HistoricRadiationAndWeatherResponse>(null, rawContent);
        }

        /// <param name="start">ISO_8601 compliant starting datetime for the historical data. If the supplied value does not specify a timezone, the timezone will be inferred from the time_zone parameter, if supplied. Otherwise UTC is assumed.</param>
        /// <param name="end">Must include one of end_date and duration. ISO_8601 compliant ending datetime for the historical data. Must be within 31 days of the start_date. If the supplied value does not specify a timezone, the timezone will be inferred from the time_zone parameter, if supplied. Otherwise UTC is assumed.</param>
        /// <param name="duration">Must include one of end_date and duration. ISO_8601 compliant duration for the historical data. Must be within 31 days of the start_date.</param>
        /// <param name="timeZone">Timezone to return in data set. Accepted values are utc, longitudinal, or a range from -13 to 13 in 0.25 hour increments for utc offset.</param>
        /// <param name="period">Length of the averaging period in ISO 8601 format.</param>
        /// <param name="latitude">The latitude of the location you request data for. Must be a decimal number between -90 and 90.</param>
        /// <param name="longitude">The longitude of the location you request data for. Must be a decimal number between -180 and 180.</param>
        /// <param name="capacity">The capacity of the inverter (AC) or the modules (DC), whichever is greater, in kilowatts (kW).</param>
        /// <param name="tilt">The angle (degrees) that the PV system is tilted off the horizontal. A tilt of 0 means the system faces directly upwards, and 90 means the system is vertical and facing the horizon. If you don't specify tilt, we use a default tilt angle based on the latitude you specify in your request. Must be between 0 and 90.</param>
        /// <param name="azimuth">The azimuth is defined as the angle (degrees) from true north that the PV system is facing. An azimuth of 0 means the system is facing true north. Positive values are anticlockwise, so azimuth is -90 for an east-facing system and 135 for a southwest-facing system. If you don't specify an azimuth, we use a default value of 0 (north facing) in the southern hemisphere and 180 (south-facing) in the northern hemisphere.</param>
        /// <param name="installDate">The date (yyyy-MM-dd) of installation of the PV system. We use this to estimate your loss_factor based on the ageing of your system. If you provide us with a loss_factor directly, we will ignore this date.</param>
        /// <param name="lossFactor">Default is 0.90 A factor to reduce your output forecast from the full capacity based on characteristics of the PV array or inverter. This is effectively the non-temperature loss effects on the nameplate rating of the PV system, including inefficiency and soiling. For a 1kW PV system anything that reduces 1000W/m2 solar radiation from producing 1000W of power output (assuming temperature is 25C). Valid values are between 0 and 1 (i.e. 0.6 equals 60%). If you specify 0.6 your returned power will be a maximum of 60% of AC capacity.</param>
        /// <param name="hours">The number of hours to return in the response.</param>
        /// <param name="outputParameters">The output parameters to include in the response.</param>
        /// <param name="terrainShading">If true, irradiance parameters are modified based on the surrounding terrain from a 90m-horizontal-resolution digital elevation model. The direct component of irradiance is set to zero when the beam from the sun is blocked by the terrain. The diffuse component of irradiance is reduced throughout the day if the sky view at the location is significantly reduced by the surrounding terrain. Global irradiance incorporates both effects.</param>
        /// <param name="format">Response format</param>
        public async Task<ApiResponse<HistoricPvPowerResponse>> GetRooftopPvPower(
            string start,
            double? latitude,
            double? longitude,
            float? capacity,
            string end = null,
            string duration = null,
            string timeZone = null,
            string period = null,
            float? tilt = null,
            float? azimuth = null,
            string installDate = null,
            float? lossFactor = null,
            int? hours = null,
            List<string> outputParameters = null,
            bool? terrainShading = null,
            string format = null
        )
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("start", start.ToString());
            parameters.Add("latitude", latitude.ToString());
            parameters.Add("longitude", longitude.ToString());
            parameters.Add("capacity", capacity.ToString());
            if (end != null) parameters.Add("end", end.ToString());
            if (duration != null) parameters.Add("duration", duration.ToString());
            if (timeZone != null) parameters.Add("timeZone", timeZone.ToString());
            if (period != null) parameters.Add("period", period.ToString());
            if (tilt.HasValue) parameters.Add("tilt", tilt.Value.ToString());
            if (azimuth.HasValue) parameters.Add("azimuth", azimuth.Value.ToString());
            if (installDate != null) parameters.Add("installDate", installDate.ToString());
            if (lossFactor.HasValue) parameters.Add("lossFactor", lossFactor.Value.ToString());
            if (hours.HasValue) parameters.Add("hours", hours.Value.ToString());
            if (outputParameters != null && outputParameters.Any()) parameters.Add("outputParameters", string.Join(",", outputParameters));
            if (terrainShading.HasValue) parameters.Add("terrainShading", terrainShading.Value.ToString());
            if (format != null) parameters.Add("format", format.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.HistoricRooftopPvPower + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<HistoricPvPowerResponse>(rawContent);
                return new ApiResponse<HistoricPvPowerResponse>(data, rawContent);
            }
            return new ApiResponse<HistoricPvPowerResponse>(null, rawContent);
        }
    }
}
