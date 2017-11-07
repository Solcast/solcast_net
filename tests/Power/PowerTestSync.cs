using System.Diagnostics;
using ServiceStack.Text;
using Xunit;

namespace Solcast.Tests
{
    public class PowerTestSync
    {
        [Fact]
        public void TestPowerForecast()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            var results = Power.Forecast(location);
            Assert.NotNull(results);
            Assert.NotNull(results.Forecasts);
            Assert.True(results.Forecasts.Count == ForecastDefault.Count);
        }
        [Fact]
        public void TestPowerEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            var results = Power.EstimatedActuals(location);
            Assert.NotNull(results);
            Assert.NotNull(results.EstimatedActuals);            
        }
        [Fact]
        public void TestPowerLatestEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            var results = Power.LatestEstimatedActuals(location);
            Assert.NotNull(results);
            Assert.NotNull(results.EstimatedActuals);            
        }        
    }
}