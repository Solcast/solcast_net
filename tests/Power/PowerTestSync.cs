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
            var results = sync.Power.Forecast(location);
            Assert.NotNull(results);
            Assert.NotNull(results.Forecasts);
            Assert.True(results.Forecasts.Count == ForecastDefault.Count);
        }
        [Fact]
        public void TestPowerEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            var results = sync.Power.EstimatedActuals(location);
            Assert.NotNull(results);
            Assert.NotNull(results.EstimatedActuals);            
        }
        [Fact]
        public void TestPowerLatestEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            var results = sync.Power.LatestEstimatedActuals(location);
            Assert.NotNull(results);
            Assert.NotNull(results.EstimatedActuals);            
        }        
    }
}