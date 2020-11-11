using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using HtmlAgilityPack;


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


        [Theory]
        [InlineData("https://localhost:44356/Cache/Work1111/Index")]
        public async Task TestContent(string url)
        {
            //Arrange
            HtmlDocument htmlDocument = new HtmlWeb().Load(url);
            List<string> val = new List<string>();

            //Action
            var nodes = htmlDocument.DocumentNode.SelectNodes("//form");
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    if (node.Attributes["action"]?.Value != null)
                    {
                        val.Add(node.Attributes["action"]?.Value);
                    }
                }
            }
 

            //Assert
            Assert.Equal("/cache/Work1111/Add", val[0]);
        }

    }
}
