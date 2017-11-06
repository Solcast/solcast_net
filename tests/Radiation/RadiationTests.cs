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
            var location = LocationExtensions.Random();
            var results = Radiation.Sync.Forecast(location);
            Assert.NotNull(results);
            Assert.NotNull(results.Forecasts);
            Assert.True(results.Forecasts.Count == 336);
        }        
        
        [Fact]
        public void TestRadiation()
        {
            var location = LocationExtensions.Random();
            var testTask = new List<Task>
            {
                Task.Run(async () =>
                {
                    var results = await Radiation.Forecast(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.Forecasts);
                    Assert.True(results.Forecasts.Count == 336);
                })
            };
            Task.WaitAll(testTask.ToArray());
        }
    }
}