using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using HtmlAgilityPack;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

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

        [Theory]
        [InlineData("https://localhost:44356/Cart/Index")]
        [InlineData("https://localhost:44356/Work1010/Index")]
        [InlineData("https://localhost:44356/Work1010/Index1111111111")]
        public void TestHtmlPagesWithAgility(string url)
        {
            //организация
            HtmlDocument doc = new HtmlWeb().Load(url);
            List<string> val = new List<string>();


            //действие
            var nodes = doc.DocumentNode.SelectNodes("//form");
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
            //утверждение
            Assert.True(val.Count > 0);
        }


        [Theory]
        [InlineData("https://localhost:44356/api/Apipi")]
        public async void SendData(string url)
        {
            //организация
            var client = factory.CreateClient();

            //действие
            var response =  client.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
               Content = new StringContent("{\"Text\":\"John Doe\"}", encoding: Encoding.UTF8, mediaType: "application/json")
            }).Result;

            //утверждение
           Assert.Equal("John Doe addons", response.Content.ReadAsStringAsync().Result);

        }


    }
}
