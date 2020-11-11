using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class IntegrTest1111 : IClassFixture<WebApplicationFactory<EFCoreTesting.Startup>>
    {
        private readonly WebApplicationFactory<EFCoreTesting.Startup> factory;

        public IntegrTest1111(WebApplicationFactory<EFCoreTesting.Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [InlineData("/Cache/Work1111/Index")]
        public async Task TestMethodIntegra(string url)
        {
            //Arrange
            var client = factory.CreateClient();

            //Action
            var response = await client.GetAsync(url);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html", response.Content.Headers.ContentType.MediaType.ToString());
        }
    }
}
