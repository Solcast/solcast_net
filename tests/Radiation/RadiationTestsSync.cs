using Xunit;

namespace solcast.tests
{
    public class RadiationTestsSync
    {
        [Fact]
        public void TestRadiationForecast()
        {
            var location = Places.Sydney();
            var results = sync.Radiation.Forecast(location);
            Assert.NotNull(results);
            Assert.NotNull(results.Forecasts);
            Assert.True(results.Forecasts.Count == ForecastDefault.Count);
        }        
        [Fact]
        public void TestRadiationEstimatedActuals()
        {
            var location = Places.Sydney();
            var results = sync.Radiation.EstimatedActuals(location);
            Assert.NotNull(results);
            Assert.NotNull(results.EstimatedActuals);
            
        }  
        [Fact]
        public void TestRadiationLatestEstimatedActuals()
        {
            var location = Places.Sydney();
            var results = sync.Radiation.LatestEstimatedActuals(location);
            Assert.NotNull(results);
            Assert.NotNull(results.EstimatedActuals);            
        }                    
    }
}