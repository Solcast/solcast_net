using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ServiceStack.Text;
using Xunit;

namespace solcast.tests
{
    public class PowerTests
    {


        [Fact]
        public void TestPowerForecast()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());            
            var testTask = new List<Task>
            {
                Task.Run(async () =>
                {
                    var results = await Power.Forecast(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.Forecasts);
                    Assert.True(results.Forecasts.Count == ForecastDefault.Count);
                })
            };
            Task.WaitAll(testTask.ToArray());
        }
        [Fact]
        public void TestPowerEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());            
            var testTask = new List<Task>
            {
                Task.Run(async () =>
                {
                    var results = await Power.EstimatedActuals(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.EstimatedActuals);                    
                })
            };
            Task.WaitAll(testTask.ToArray());
        }
        [Fact]
        public void TestPowerLatestEstimatedActuals()
        {
            var location = Places.Sydney();
            Debug.WriteLine(location.Dump());            
            var testTask = new List<Task>
            {
                Task.Run(async () =>
                {
                    var results = await Power.LatestEstimatedActuals(location);
                    Assert.NotNull(results);
                    Assert.NotNull(results.EstimatedActuals);
                    
                })
            };
            Task.WaitAll(testTask.ToArray());
        }        
    }
}