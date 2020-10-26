using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.After2610
{
    public class Work2510Tests : IClassFixture<WebApplicationFactory<EFCoreTesting.Startup>>
    {
        private readonly WebApplicationFactory<EFCoreTesting.Startup> factory;

        public Work2510Tests(WebApplicationFactory<EFCoreTesting.Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [InlineData("/Work2510UniqueContext?id=22")]
        public async void ReturnStatusSuccess(string url)
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode(); //возвратит ошибку, если статус код не 200-299
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/Work2510UniqueContext?id=22")]
        public async void ContainsLastnameVoroshilov(string url)
        {
            HtmlDocument doc = await new HtmlWeb().LoadFromWebAsync(url);
            var data = doc.ParsedText.Contains("Сергей -- Ворошилов");

            Assert.True(data);
        }
    }
}
