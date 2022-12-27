using Exercise.ServiceModels;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Exercise.IntegrationTesting.Tests
{
    public class CountryControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetsAllCountries()
        {
            // Act
            var response = await _httpClient.GetAsync("/api/Country/GetAll");
            var contacts = await response.Content.ReadFromJsonAsync<List<CountryServiceModel>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            contacts.Should().NotBeNull();
            contacts.Should().NotBeEmpty();
        }
    }
}
