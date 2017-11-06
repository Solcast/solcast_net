using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace solcast.tests
{
    public class RadiationTests
    {
        [Fact]
        public void TestRadiationForecast()
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
        [Fact]
        public void TestRadiationEstimatedActuals()
        {
            var location = LocationExtensions.Random();
            var testTask = new List<Task>
            {
                Task.Run(async () =>
                {
                    var results = await Radiation.EstimatedActuals(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.EstimatedActuals);
                    //Assert.True(results.EstimatedActuals.Count == 336);
                })
            };
            Task.WaitAll(testTask.ToArray());
        }
        [Fact]
        public void TestRadiationLatestEstimatedActuals()
        {
            var location = LocationExtensions.Random();
            var testTask = new List<Task>
            {
                Task.Run(async () =>
                {
                    var results = await Radiation.LatestEstimatedActuals(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.EstimatedActuals);
                    //Assert.True(results.EstimatedActuals.Count == 336);
                })
            };
            Task.WaitAll(testTask.ToArray());
        }
        
    }
}