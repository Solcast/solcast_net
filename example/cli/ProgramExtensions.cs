using System;
using System.Diagnostics;
using System.Linq;
using ServiceStack.Text;
using Solcast.Types;

namespace Cli
{
    public static class ProgramExtensions
    {
        public static void ToConsole(this GetPvPowerForecastsResponse response)
        {
            Console.WriteLine($"Total Forecast Intervals {response.Forecasts.Count}");
            foreach (var currentForecast in response.Forecasts.Select((row, index) => new {index, row}))
            {
                Console.WriteLine($"{currentForecast.index} - {currentForecast.row.Dump()}");
            }            
        }

        public static GetPvPowerForecastsResponse Validate(this GetPvPowerForecastsResponse forecast)
        {
            if (forecast.ResponseStatus?.Errors == null || !forecast.ResponseStatus.Errors.Any())
            {
                return forecast;
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