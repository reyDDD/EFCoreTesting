using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests
{
    public class PagesTest : IClassFixture<WebApplicationFactory<EFCoreTesting.Startup>>
    {
        private readonly WebApplicationFactory<EFCoreTesting.Startup> factory;

        public PagesTest(WebApplicationFactory<EFCoreTesting.Startup> factory)
        {
            this.factory = factory;
        }


        [Theory]
        [InlineData("/Carta/Index")]
        [InlineData("/Work1010/Index")]
        [InlineData("/Work1010/Index1111111111")]
        public async void TestResponsePages(string url)
        {
            //организация
            var client = factory.CreateClient();

            //действие
            var response = await client.GetAsync(url);

            //утверждение
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
