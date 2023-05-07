using FruitVice_API_IntegrationTest.Constants;
using FruitVice_API_IntegrationTest.Providers;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace FruitVice_API_IntegrationTest
{
    public class FruityViceIntegrationTest
    {
        [Fact]
        public async Task Test1()
        {
            // Arrange
            var client = new TestClientProvider().HttpClient;
           
            // Act
            var response = await client.GetAsync(EndPointsURl.FServiceURL);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAllFruitsByFamily()
        {
            // Arrange
            var client = new TestClientProvider().HttpClient;
            var parameters = "Rosaceae";

            // Act
            var response = await client.GetAsync(EndPointsURl.FServiceURL +  parameters);

            // Asset
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
