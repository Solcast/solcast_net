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
            var location = Places.Sydney();
            var testTask = new List<Task>
            {
                Task.Run(async () =>
                {
                    var results = await Radiation.Forecast(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.Forecasts);
                    Assert.True(results.Forecasts.Count == ForecastDefault.Count);
                })
            };
            Task.WaitAll(testTask.ToArray());
        }
        [Fact]
        public void TestRadiationEstimatedActuals()
        {
            var location = Places.Sydney();
            var testTask = new List<Task>
            {
                Task.Run(async () =>
                {
                    var results = await Radiation.EstimatedActuals(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.EstimatedActuals);                 
                })
            };
            Task.WaitAll(testTask.ToArray());
        }
        [Fact]
        public void TestRadiationLatestEstimatedActuals()
        {
            var location = Places.Sydney();
            var testTask = new List<Task>
            {
                Task.Run(async () =>
                {
                    var results = await Radiation.LatestEstimatedActuals(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.EstimatedActuals);
                    
                })
            };
            Task.WaitAll(testTask.ToArray());
        }
        
    }
}