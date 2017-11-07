using System.Diagnostics;
using ServiceStack.Text;
using Xunit;

namespace solcast.tests
{
    public class PowerTestSync
    {
        [Fact]
        public void TestPowerForecast()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            var results = Power.Sync.Forecast(location);
            Assert.NotNull(results);
            Assert.NotNull(results.Forecasts);
            Assert.True(results.Forecasts.Count == 336);
        }
        [Fact]
        public void TestPowerEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            var results = Power.Sync.EstimatedActuals(location);
            Assert.NotNull(results);
            Assert.NotNull(results.EstimatedActuals);
            //Assert.True(results.EstimatedActuals.Count == 336);
        }
        [Fact]
        public void TestPowerLatestEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            var results = Power.Sync.LatestEstimatedActuals(location);
            Assert.NotNull(results);
            Assert.NotNull(results.EstimatedActuals);
            //Assert.True(results.EstimatedActuals.Count == 336);
        }        
    }
}