using System;
using System.Diagnostics;
using System.Linq;
using solcast.types;
using ServiceStack.Text;

namespace solcast.cli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var location = new Location
            {
                Latitude = 32,
                Longitude = -97
            };
            try
            {
                Console.WriteLine($"SOLCAST_API_KEY = {API.Key()}");
                Console.Write($"Current API timeout setting = {API.Timeout}");

                // Sync call
                //var response = sync.Power.Forecast(location);

                var getForecast = Power.Forecast(location);
                getForecast.Wait();
                var response = getForecast.Result;
                ValidateResponse(response);
                WriteToDisplay(response);
            }
            catch (Exception e)
            {
                if (Debugger.IsAttached) { Debugger.Break(); }
                Console.WriteLine(e);
            }
        }

        private static void WriteToDisplay(GetPvPowerForecastsResponse response)
        {
            Console.WriteLine($"Total Forecast Intervals {response.Forecasts.Count}");
            foreach (var currentForecast in response.Forecasts.Select((row, index) => new {index, row}))
            {
                Console.WriteLine($"{currentForecast.index} - {currentForecast.row.Dump()}");
            }
        }

        private static void ValidateResponse(GetPvPowerForecastsResponse forecast)
        {
            if (forecast.ResponseStatus?.Errors == null || !forecast.ResponseStatus.Errors.Any())
            {
                return;
            }            
            foreach (var error in forecast.ResponseStatus.Errors)
            {
                if (Debugger.IsAttached) { Debugger.Break(); }             
                Console.WriteLine($"Issue: {error.Dump()}");
            }
            throw new ApplicationException("Forecast request failed");
        }
    }
}
