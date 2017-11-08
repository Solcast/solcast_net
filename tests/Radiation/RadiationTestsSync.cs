using System.Diagnostics;
using ServiceStack.Text;
using Xunit;

namespace Solcast.Tests
{
    public class RadiationTestsSync
    {
        [Fact]
        public void TestRadiationForecast()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());

            using (var client = new SolcastClient())
            {
                var results = client.GetRadiationForecasts(location);
                Assert.NotNull(results);
                Assert.NotNull(results.Forecasts);
                Assert.True(results.Forecasts.Count == ForecastDefault.Count);                
            }
        }
        [Fact]
        public void TestRadiationEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            using (var client = new SolcastClient())
            {
                var results = client.GetRadiationEstimatedActuals(location);
                Assert.NotNull(results);
                Assert.NotNull(results.EstimatedActuals);
            }
        }
        [Fact]
        public void TestRadiationLatestEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            using (var client = new SolcastClient())
            {
                var results = client.GetLatestRadiationEstimatedActuals(location);
                Assert.NotNull(results);
                Assert.NotNull(results.EstimatedActuals);                            
            }
        }                     
    }
}