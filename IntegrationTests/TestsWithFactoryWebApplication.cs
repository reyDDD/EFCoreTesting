using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class TestsWithFactoryWebApplication : IClassFixture<CustomWebApplicationFactory<EFCoreTesting.Startup>>
{
        private readonly HttpClient _httpClient;
        private readonly CustomWebApplicationFactory<EFCoreTesting.Startup> _factory;

        public TestsWithFactoryWebApplication(CustomWebApplicationFactory<EFCoreTesting.Startup> _factory)
        {
            this._factory = _factory;
            _httpClient = _factory.CreateClient(new WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = false
            });
        }



        [Fact]
        public async Task GePpageWithHttpClient()
        {
            // Arrange
            var defaultPage = await _httpClient.GetAsync("/OneMany/Work2109/");
            var content = defaultPage.StatusCode;
            var res = defaultPage.Content.ReadAsStringAsync().Result;

            Assert.Equal(HttpStatusCode.OK, content);
            Assert.Contains("/OneMany/Update2109Address", res);

            var response = await _httpClient.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44356/api/Apipi"),
            });
            var otvet = response.Content.ReadAsStringAsync().Result;

            Assert.Contains("value1", otvet);


        }
    }
}
