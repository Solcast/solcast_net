using NUnit.Framework;
using Solcast;
using Solcast.Clients;
using System;
using System.Threading.Tasks;

namespace Solcast.Tests
{
    [TestFixture]
    public class HistoricClientTests
    {
        private HistoricClient _historicClient;
        private string _originalApiKey;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Capture the original API key (if it exists)
            _originalApiKey = Environment.GetEnvironmentVariable("SOLCAST_API_KEY");
        }

        [SetUp]
        public void Setup()
        {
            // Reuse the original API key (if it exists)
            Environment.SetEnvironmentVariable("SOLCAST_API_KEY", _originalApiKey);

            // Initialize the HistoricClient
            _historicClient = new HistoricClient();
        }

        [TearDown]
        public void TearDown()
        {
            // Reset the environment variable to the original API key after each test
            Environment.SetEnvironmentVariable("SOLCAST_API_KEY", _originalApiKey);
        }

        [Test]
        public async Task GetHistoricRadiationAndWeather_ShouldReturnValidData()
        {
            // Arrange
            double latitude = -33.856784;
            double longitude = 151.215297;
            string start = "2022-06-01T06:00";
            string duration = "P1D";
            string format = "json";

            // Act
            var response = await _historicClient.GetRadiationAndWeather(
                latitude: latitude,
                longitude: longitude,
                start: start,
                duration: duration,
                format: format
            );

            // Assert
            Assert.IsNotNull(response);
            // Additional assertions can be added here based on response structure
        }

        [Test]
        public void GetHistoricRadiationAndWeather_ShouldThrowException_WhenApiKeyIsMissing()
        {
            // Arrange
            Environment.SetEnvironmentVariable("SOLCAST_API_KEY", null);
            _historicClient = new HistoricClient();

            // Act & Assert
            Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            {
                await _historicClient.GetRadiationAndWeather(
                    latitude: -33.856784,
                    longitude: 151.215297,
                    start: "2022-06-01T06:00",
                    duration: "P1D",
                    format: "json"
                );
            });
        }

        [Test]
        public async Task GetHistoricRooftopPvPower_ShouldReturnValidData()
        {
            // Arrange
            double latitude = -33.856784;
            double longitude = 151.215297;
            string start = "2022-06-01T06:00";
            string duration = "P1D";
            float capacity = 5;
            string format = "json";

            // Act
            var response = await _historicClient.GetRooftopPvPower(
                latitude: latitude,
                longitude: longitude,
                start: start,
                duration: duration,
                capacity: capacity,
                format: format
            );

            // Assert
            Assert.IsNotNull(response);
            // Additional assertions based on response data structure
        }

        [Test]
        public void GetHistoricRooftopPvPower_ShouldThrowException_WhenApiKeyIsMissing()
        {
            // Arrange
            Environment.SetEnvironmentVariable("SOLCAST_API_KEY", null);
            _historicClient = new HistoricClient();
            double latitude = -33.856784;
            double longitude = 151.215297;
            string start = "2022-06-01T06:00";
            string duration = "P1D";
            float capacity = 5;
            string format = "json";

            // Act & Assert
            Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            {
                await _historicClient.GetRooftopPvPower(
                    latitude: latitude,
                    longitude: longitude,
                    start: start,
                    duration: duration,
                    capacity: capacity,
                    format: format
                );
            });
        }

        [Test]
        public async Task GetHistoricAdvancedPvPower_ShouldReturnValidData()
        {
            // Arrange
            string resourceId = UnmeteredLocations.Locations["Sydney Opera House"].ResourceId;
            string start = "2022-06-01T06:00";
            string duration = "P1D";
            string format = "json";

            // Act
            var response = await _historicClient.GetAdvancedPvPower(
                resourceId: resourceId,
                start: start,
                duration: duration,
                format: format
            );

            // Assert
            Assert.IsNotNull(response);
            // Additional assertions based on response data structure
        }

        [Test]
        public void GetHistoricAdvancedPvPower_ShouldThrowException_WhenApiKeyIsMissing()
        {
            // Arrange
            Environment.SetEnvironmentVariable("SOLCAST_API_KEY", null);
            _historicClient = new HistoricClient();
            string resourceId = UnmeteredLocations.Locations["Sydney Opera House"].ResourceId;
            string start = "2022-06-01T06:00";
            string duration = "P1D";
            string format = "json";

            // Act & Assert
            Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
            {
                await _historicClient.GetAdvancedPvPower(
                    resourceId: resourceId,
                    start: start,
                    duration: duration,
                    format: format
                );
            });
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Restore the original API key after all tests
            Environment.SetEnvironmentVariable("SOLCAST_API_KEY", _originalApiKey);
        }
    }
}
