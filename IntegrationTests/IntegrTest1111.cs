using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using HtmlAgilityPack;
using Microsoft.Extensions.DependencyInjection;
using EFCoreTesting.Areas.Distribute.Controllers;
using Microsoft.Extensions.Logging;

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


        [Theory]
        [InlineData("https://localhost:44356/Cache/Work1111/Index")]
        public async Task TestWithWebHostBuilder(string url)
        {
            //Arrange
            var client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var serviceProvider = services.BuildServiceProvider();
                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedService = scope.ServiceProvider;
                        var logger = scopedService.GetRequiredService<ILogger<Work1111Controller>>();
                        logger.LogWarning("yes today");
                    }
                });
            });

            var workKlient = client.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });

            //Action
            var page = await workKlient.GetAsync(url);

            var result = await page.Content.ReadAsStringAsync();
            //Assert
            Assert.Contains("/cache/Work1111/Add", result);
        }


    }
}
