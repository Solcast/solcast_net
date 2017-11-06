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
            var location = LocationExtensions.Random();
            var results = Power.Sync.Forecast(location);
            Assert.NotNull(results);
            Assert.NotNull(results.Forecasts);
            Assert.True(results.Forecasts.Count == 336);
        }             
        
        [Fact]
        public void TestPower()
        {
            var location = LocationExtensions.Random();
            var testTask = new List<Task>
            {
                Task.Run(async () =>
                {
                    var results = await Power.Forecast(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.Forecasts);
                    Assert.True(results.Forecasts.Count == 336);
                })
            };
            Task.WaitAll(testTask.ToArray());
        }                
    }
}