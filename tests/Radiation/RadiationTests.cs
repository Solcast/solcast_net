using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace solcast.tests
{
    public class RadiationTests
    {
        [Fact]
        public void TestRadiationSync()
        {
            var location = new Location
            {
                Latitude = 32,
                Longitude = -97
            };
            try
            {
                var results = Radiation.Sync.Forecast(location);
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
        
        [Fact]
        public void TestRadiation()
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
                        var results = await Radiation.Forecast(location, API.Key(null));
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
    }
}