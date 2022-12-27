using Exercise.ServiceModels;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Exercise.IntegrationTesting.Tests
{
    public class CompanyControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetsAllCompanies()
        {
            // Act
            var response = await _httpClient.GetAsync("/api/Company/GetAll");
            var contacts = await response.Content.ReadFromJsonAsync<List<CompanyServiceModel>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            contacts.Should().NotBeNull();
            contacts.Should().NotBeEmpty();
        }
    }
}
