using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace solcast.tests
{
    public class PowerTests
    {
        [Fact]
        public void TestPowerSync()
        {
            var location = new Location
            {
                Latitude = 32,
                Longitude = -97
            };
            try
            {
                var testTask = new List<Task>
                {
                    Task.Run(async () =>
                    {
                        var results = await Power.Forecast(location, API.Key(null));
                        Assert.NotNull(results);
                        Assert.NotNull(results.Forecasts);
                        Assert.NotEmpty(results.Forecasts);
                    })
                };
                Task.WaitAll(testTask.ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        
        [Fact]
        public void TestPower()
        {
            var location = new Location
            {
                Latitude = 32,
                Longitude = -97
            };
            try
            {
                var results = Power.Forecast(location).Result;
                Assert.NotNull(results);
                Assert.NotNull(results.Forecasts);
                Assert.NotEmpty(results.Forecasts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}