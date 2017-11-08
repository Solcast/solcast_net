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

            using (var client = new SolcastClient())
            {
                var results = client.GetPvPowerForecasts(location);
                Assert.NotNull(results);
                Assert.NotNull(results.Forecasts);
                Assert.True(results.Forecasts.Count == ForecastDefault.Count);                
            }
        }
        [Fact]
        public void TestPowerEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            using (var client = new SolcastClient())
            {
                var results = client.GetPvPowerEstimatedActuals(location);
                Assert.NotNull(results);
                Assert.NotNull(results.EstimatedActuals);
            }
        }
        [Fact]
        public void TestPowerLatestEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            using (var client = new SolcastClient())
            {
                var results = client.GetLatestPvPowerEstimatedActuals(location);
                Assert.NotNull(results);
                Assert.NotNull(results.EstimatedActuals);                            
            }
        }        
    }
}