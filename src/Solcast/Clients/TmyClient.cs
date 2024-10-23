
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Solcast.Utilities;

namespace Solcast.Clients
{
    public class TmyClient : BaseClient
    {
        public TmyClient()
        {
        }

        public async Task<ApiResponse<TmyAdvancedPvPowerResponse>> GetAdvancedPvPower(
            string resourceId,
            string timeZone = null,
            string period = null,
            double? ghiWeight = null,
            double? dniWeight = null,
            string probability = null,
            List<string> outputParameters = null,
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
            parameters.Add("resourceId", resourceId.ToString());
            if (timeZone != null) parameters.Add("timeZone", timeZone.ToString());
            if (period != null) parameters.Add("period", period.ToString());
            if (ghiWeight.HasValue) parameters.Add("ghiWeight", ghiWeight.Value.ToString());
            if (dniWeight.HasValue) parameters.Add("dniWeight", dniWeight.Value.ToString());
            if (probability != null) parameters.Add("probability", probability.ToString());
            if (outputParameters != null && outputParameters.Any()) parameters.Add("outputParameters", string.Join(",", outputParameters));
            if (hours.HasValue) parameters.Add("hours", hours.Value.ToString());
            if (applyAvailability.HasValue) parameters.Add("applyAvailability", applyAvailability.Value.ToString());
            if (applyConstraint.HasValue) parameters.Add("applyConstraint", applyConstraint.Value.ToString());
            if (applyDustSoiling.HasValue) parameters.Add("applyDustSoiling", applyDustSoiling.Value.ToString());
            if (applySnowSoiling.HasValue) parameters.Add("applySnowSoiling", applySnowSoiling.Value.ToString());
            if (applyTrackerInactive.HasValue) parameters.Add("applyTrackerInactive", applyTrackerInactive.Value.ToString());
            if (terrainShading.HasValue) parameters.Add("terrainShading", terrainShading.Value.ToString());
            if (format != null) parameters.Add("format", format.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.TmyAdvancedPvPower + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<TmyAdvancedPvPowerResponse>(rawContent);
                return new ApiResponse<TmyAdvancedPvPowerResponse>(data, rawContent);
            }
            return new ApiResponse<TmyAdvancedPvPowerResponse>(null, rawContent);
        }

        public async Task<ApiResponse<TmyRadiationAndWeatherResponse>> GetRadiationAndWeather(
            double? latitude,
            double? longitude,
            string timeZone = null,
            string period = null,
            double? ghiWeight = null,
            double? dniWeight = null,
            string probability = null,
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
            parameters.Add("latitude", latitude.ToString());
            parameters.Add("longitude", longitude.ToString());
            if (timeZone != null) parameters.Add("timeZone", timeZone.ToString());
            if (period != null) parameters.Add("period", period.ToString());
            if (ghiWeight.HasValue) parameters.Add("ghiWeight", ghiWeight.Value.ToString());
            if (dniWeight.HasValue) parameters.Add("dniWeight", dniWeight.Value.ToString());
            if (probability != null) parameters.Add("probability", probability.ToString());
            if (tilt.HasValue) parameters.Add("tilt", tilt.Value.ToString());
            if (azimuth.HasValue) parameters.Add("azimuth", azimuth.Value.ToString());
            if (arrayType != null) parameters.Add("arrayType", arrayType.ToString());
            if (outputParameters != null && outputParameters.Any()) parameters.Add("outputParameters", string.Join(",", outputParameters));
            if (terrainShading.HasValue) parameters.Add("terrainShading", terrainShading.Value.ToString());
            if (hours.HasValue) parameters.Add("hours", hours.Value.ToString());
            if (format != null) parameters.Add("format", format.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.TmyRadiationAndWeather + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<TmyRadiationAndWeatherResponse>(rawContent);
                return new ApiResponse<TmyRadiationAndWeatherResponse>(data, rawContent);
            }
            return new ApiResponse<TmyRadiationAndWeatherResponse>(null, rawContent);
        }

        public async Task<ApiResponse<TmyRooftopPvPowerResponse>> GetRooftopPvPower(
            double? latitude,
            double? longitude,
            float? capacity,
            string timeZone = null,
            string period = null,
            double? ghiWeight = null,
            double? dniWeight = null,
            string probability = null,
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
            parameters.Add("latitude", latitude.ToString());
            parameters.Add("longitude", longitude.ToString());
            parameters.Add("capacity", capacity.ToString());
            if (timeZone != null) parameters.Add("timeZone", timeZone.ToString());
            if (period != null) parameters.Add("period", period.ToString());
            if (ghiWeight.HasValue) parameters.Add("ghiWeight", ghiWeight.Value.ToString());
            if (dniWeight.HasValue) parameters.Add("dniWeight", dniWeight.Value.ToString());
            if (probability != null) parameters.Add("probability", probability.ToString());
            if (tilt.HasValue) parameters.Add("tilt", tilt.Value.ToString());
            if (azimuth.HasValue) parameters.Add("azimuth", azimuth.Value.ToString());
            if (installDate != null) parameters.Add("installDate", installDate.ToString());
            if (lossFactor.HasValue) parameters.Add("lossFactor", lossFactor.Value.ToString());
            if (hours.HasValue) parameters.Add("hours", hours.Value.ToString());
            if (outputParameters != null && outputParameters.Any()) parameters.Add("outputParameters", string.Join(",", outputParameters));
            if (terrainShading.HasValue) parameters.Add("terrainShading", terrainShading.Value.ToString());
            if (format != null) parameters.Add("format", format.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.TmyRooftopPvPower + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<TmyRooftopPvPowerResponse>(rawContent);
                return new ApiResponse<TmyRooftopPvPowerResponse>(data, rawContent);
            }
            return new ApiResponse<TmyRooftopPvPowerResponse>(null, rawContent);
        }
    }
}
