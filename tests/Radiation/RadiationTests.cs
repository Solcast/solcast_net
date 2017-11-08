using System.Diagnostics;
using System.Threading.Tasks;
using ServiceStack.Text;
using Xunit;

namespace Solcast.Tests
{
    public class RadiationTests
    {
        [Fact]
        public void TestRadiationForecast()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            Task.Run(async () =>
            {
                using (var client = new SolcastClient())
                {
                    var results = await client.GetRadiationForecastsAsync(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.Forecasts);
                    Assert.True(results.Forecasts.Count == ForecastDefault.Count);
                }
            }).Wait();
        }        
        [Fact]
        public void TestRadiationEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            Task.Run(async () =>
            {
                using (var client = new SolcastClient())
                {
                    var results = await client.GetRadiationEstimatedActualsAsync(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.EstimatedActuals);
                }
            }).Wait();
        }
        [Fact]
        public void TestRadiationLatestEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            Task.Run(async () =>
            {
                using (var client = new SolcastClient())
                {
                    var results = await client.GetLatestRadiationEstimatedActualsAsync(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.EstimatedActuals);
                }
            }).Wait();
        }             
    }
}