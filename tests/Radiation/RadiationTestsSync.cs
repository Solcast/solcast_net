using Xunit;

namespace solcast.tests
{
    public class RadiationTestsSync
    {
        [Fact]
        public void TestRadiationForecast()
        {
            var location = LocationExtensions.Random();
            var results = Radiation.Sync.Forecast(location);
            Assert.NotNull(results);
            Assert.NotNull(results.Forecasts);
            Assert.True(results.Forecasts.Count == 336);
        }        
        [Fact]
        public void TestRadiationEstimatedActuals()
        {
            var location = LocationExtensions.Random();
            var results = Radiation.Sync.EstimatedActuals(location);
            Assert.NotNull(results);
            Assert.NotNull(results.EstimatedActuals);
            //Assert.True(results.EstimatedActuals.Count == 336);
        }  
        [Fact]
        public void TestRadiationLatestEstimatedActuals()
        {
            var location = LocationExtensions.Random();
            var results = Radiation.Sync.LatestEstimatedActuals(location);
            Assert.NotNull(results);
            Assert.NotNull(results.EstimatedActuals);
            //Assert.True(results.EstimatedActuals.Count == 336);
        }                    
    }
}