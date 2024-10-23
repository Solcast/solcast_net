using NUnit.Framework;
using Solcast.Clients;
using System.Threading.Tasks;

namespace Solcast.Tests
{
    [TestFixture]
    public class PvPowerSiteClientTests
    {
        private PvPowerSiteClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new PvPowerSiteClient();
        }

        [Test]
        public async Task Test_ListPvPowerSites()
        {
            // Act
            // var response = await _client.GetPvPowerSites(format: "json");
            var response = await _client.GetPvPowerSites();

            // Assert
            Assert.IsNotNull(response);
            // Assert.IsTrue(response.RawResponse.Contains("resource_id"));
            Assert.IsTrue(response.RawResponse.Contains("\"resource_id\":\"ba75-e17a-7374-95ed\""));
        }

        [Test]
        public async Task Test_GetPvPowerSite()
        {
            // Arrange
            var resourceId = UnmeteredLocations.Locations["Sydney Opera House"].ResourceId;

            // Act
            // var response = await _client.GetPvPowerSite(resourceId, format: "json");
            var response = await _client.GetPvPowerSite(resourceId);

            // Assert
            Assert.IsNotNull(response);
            // Assert.AreEqual(response.Data.ResourceId, resourceId);
            Assert.IsTrue(response.RawResponse.Contains("\"resource_id\":\"ba75-e17a-7374-95ed\""));
        }
    }
}
