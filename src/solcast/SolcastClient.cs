using System;
using ServiceStack;
using Solcast.Types;

namespace Solcast
{
    public class SolcastClient
    {
        private readonly JsonHttpClient client;
        private readonly TimeZoneInfo timeZoneInfo;

        public SolcastClient()
        {
            client = new JsonHttpClient("https://api.solcast.com.au");
        }

        public SolcastClient(string apiKey, TimeZoneInfo timeZoneInfo = null)
        {
            client.RequestFilter = message => message.AddBearerToken(apiKey);
            this.timeZoneInfo = timeZoneInfo ?? TimeZoneInfo.Utc;
        }

        public GetRadiationEstimatedActualsResponse GetRadiationEstimatedActuals(Location location)
        {
            var result = client.Get(location.ConvertTo<GetRadiationEstimatedActuals>());
            foreach (var estimatedActual in result.EstimatedActuals)
            {
                estimatedActual.PeriodEnd = TimeZoneInfo.ConvertTime(estimatedActual.PeriodEnd, timeZoneInfo);
            }
            return result;
        }
        
        public GetRadiationForecastsResponse GetRadiationForecasts(Location location)
        {
            var result = client.Get(location.ConvertTo<GetRadiationForecasts>());
            foreach (var forecast in result.Forecasts)
            {
                forecast.PeriodEnd = TimeZoneInfo.ConvertTime(forecast.PeriodEnd, timeZoneInfo);
            }
            return result;
        }

        public GetPvPowerEstimatedActualsResponse GetPvPowerEstimatedActuals(Location location, PvSystem pvSystem)
        {
            var reqObj = location.ConvertTo<GetPvPowerEstimatedActuals>();
            reqObj.PopulateWithNonDefaultValues(pvSystem);
            var result = client.Get(reqObj);
            foreach (var estimatedActual in result.EstimatedActuals)
            {
                estimatedActual.PeriodEnd = TimeZoneInfo.ConvertTime(estimatedActual.PeriodEnd, timeZoneInfo);
            }
            return result;
        }
        
        public GetPvPowerForecastsResponse GetPvPowerForecasts(Location location, PvSystem pvSystem)
        {
            var reqObj = location.ConvertTo<GetPvPowerForecasts>();
            reqObj.PopulateWithNonDefaultValues(pvSystem);
            var result = client.Get(reqObj);
            foreach (var forecast in result.Forecasts)
            {
                forecast.PeriodEnd = TimeZoneInfo.ConvertTime(forecast.PeriodEnd, timeZoneInfo);
            }
            return result;
        }
    }
}