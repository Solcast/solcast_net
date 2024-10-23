using NUnit.Framework;
using Solcast.Clients;
using System.Threading.Tasks;

namespace Solcast.Tests
{
    [TestFixture]
    public class AggregationClientTests
    {
        private AggregationClient _aggregationClient;

        [SetUp]
        public void Setup()
        {
            _aggregationClient = new AggregationClient();
        }

        [Test]
        public async Task GetLiveAggregation_ShouldReturnValidData()
        {
            var response = await _aggregationClient.GetLiveAggregations(
                collectionId: "country_total",
                aggregationId: "it_total"
            );
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetForecastAggregation_ShouldReturnValidData()
        {
            var response = await _aggregationClient.GetForecastAggregations(
                collectionId: "country_total",
                aggregationId: "it_total",
                outputParameters: ["percentage", "pv_estimate"]
            );
            Assert.IsNotNull(response);
        }
    }
}
