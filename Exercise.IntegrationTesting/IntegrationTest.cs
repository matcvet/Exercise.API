using Microsoft.AspNetCore.Mvc.Testing;

namespace Exercise.IntegrationTesting
{
    public class IntegrationTest
    {
        protected readonly HttpClient _httpClient;

        public IntegrationTest()
        {
            var _factory = new WebApplicationFactory<Program>();
            _httpClient = _factory.CreateClient();
        }
    }
}
