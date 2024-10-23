
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Solcast.Utilities;

namespace Solcast.Clients
{
    public class AggregationClient : BaseClient
    {
        public AggregationClient()
        {
        }        

        public async Task<ApiResponse<LiveAggregationResponse>> GetLiveAggregations(
            List<string> outputParameters = null,
            string collectionId = null,
            string aggregationId = null,
            int? hours = null,
            string period = null,
            string format = null
        )
        {
            var parameters = new Dictionary<string, string>();
            if (outputParameters != null && outputParameters.Any()) parameters.Add("outputParameters", string.Join(",", outputParameters));
            if (collectionId != null) parameters.Add("collectionId", collectionId.ToString());
            if (aggregationId != null) parameters.Add("aggregationId", aggregationId.ToString());
            if (hours.HasValue) parameters.Add("hours", hours.Value.ToString());
            if (period != null) parameters.Add("period", period.ToString());
            if (format != null) parameters.Add("format", format.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.LiveAggregations + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<LiveAggregationResponse>(rawContent);
                return new ApiResponse<LiveAggregationResponse>(data, rawContent);
            }
            return new ApiResponse<LiveAggregationResponse>(null, rawContent);
        }        

        public async Task<ApiResponse<ForecastAggregationResponse>> GetForecastAggregations(
            List<string> outputParameters = null,
            string collectionId = null,
            string aggregationId = null,
            int? hours = null,
            string period = null,
            string format = null
        )
        {
            var parameters = new Dictionary<string, string>();
            if (outputParameters != null && outputParameters.Any()) parameters.Add("outputParameters", string.Join(",", outputParameters));
            if (collectionId != null) parameters.Add("collectionId", collectionId.ToString());
            if (aggregationId != null) parameters.Add("aggregationId", aggregationId.ToString());
            if (hours.HasValue) parameters.Add("hours", hours.Value.ToString());
            if (period != null) parameters.Add("period", period.ToString());
            if (format != null) parameters.Add("format", format.ToString());

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value ?? string.Empty)}"));
            var response = await _httpClient.GetAsync(SolcastUrls.ForecastAggregations + $"?{queryString}");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            response.EnsureSuccessStatusCode();

            var rawContent = await response.Content.ReadAsStringAsync();

            if (parameters.ContainsKey("format") && parameters["format"] == "json")
            {
                var data = JsonConvert.DeserializeObject<ForecastAggregationResponse>(rawContent);
                return new ApiResponse<ForecastAggregationResponse>(data, rawContent);
            }
            return new ApiResponse<ForecastAggregationResponse>(null, rawContent);
        }
    }
}
