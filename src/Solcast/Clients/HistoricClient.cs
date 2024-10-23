
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
