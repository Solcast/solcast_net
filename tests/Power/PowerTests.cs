using System.Diagnostics;
using System.Threading.Tasks;
using ServiceStack.Text;
using Xunit;

namespace Solcast.Tests
{
    public class PowerTests
    {
        [Fact]
        public void TestPowerForecast()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            Task.Run(async () =>
            {
                using (var client = new SolcastClient())
                {
                    var results = await client.GetPvPowerForecastsAsync(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.Forecasts);
                    Assert.True(results.Forecasts.Count == ForecastDefault.Count);
                }
            }).Wait();
        }        
        [Fact]
        public void TestPowerEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            Task.Run(async () =>
            {
                using (var client = new SolcastClient())
                {
                    var results = await client.GetPvPowerEstimatedActualsAsync(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.EstimatedActuals);
                }
            }).Wait();
        }
        [Fact]
        public void TestPowerLatestEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());
            Task.Run(async () =>
            {
                using (var client = new SolcastClient())
                {
                    var results = await client.GetLatestPvPowerEstimatedActualsAsync(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.EstimatedActuals);
                }
            }).Wait();
        }        
    }
}