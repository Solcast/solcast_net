using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Solcast.Types;
using ServiceStack.Text;
using Solcast;

namespace Cli
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
                Console.WriteLine($"Solcast_API_KEY = {API.Key()}");
                Console.Write($"Current API timeout setting = {API.Timeout}");

                // Sync call
                //var response = Power.Forecast(location);

                var tasks = new List<Task>
                {
                    Task.Run(async () =>
                    {
                        var response = await Power.ForecastAsync(location);
                        ValidateResponse(response);
                        WriteToDisplay(response);
                    })
                };
                Task.WaitAll(tasks.ToArray());
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
