using Exercise.ServiceModels;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Exercise.IntegrationTesting.Tests
{
    public class ContactControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetsContact()
        {
            // Arrange
            var id = 1;

            // Act
            var response = await _httpClient.GetAsync($"/api/Contact/GetById/{id}");
            var contact = await response.Content.ReadFromJsonAsync<ContactServiceModel>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            contact.Should().NotBeNull();
            contact.Id.Should().Be(id);
        }

        [Fact]
        public async Task GetsAllContacts()
        {
            // Act
            var response = await _httpClient.GetAsync("/api/Contact/GetAll");
            var contacts = await response.Content.ReadFromJsonAsync<List<ContactServiceModel>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            contacts.Should().NotBeNull();
            contacts.Should().NotBeEmpty();
        }
    }
}
