using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using EFCoreTesting.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http;
using EFCoreTesting.Services;

namespace IntegrationTests
{
    public class TestsWithWebHostBuilder : IClassFixture<WebApplicationFactory<EFCoreTesting.Startup>>
    {
        private readonly WebApplicationFactory<EFCoreTesting.Startup> factory;

        public TestsWithWebHostBuilder(WebApplicationFactory<EFCoreTesting.Startup> factory)
        {
            this.factory = factory;
        }


        [Fact]
        public async Task TestingWithWebHostBuilder()
        {
            var client = factory.WithWebHostBuilder(builder =>

            {
                builder.ConfigureServices(services =>
                {
                    var servicepProvider = services.BuildServiceProvider();
                    using (var scope = servicepProvider.CreateScope())
                    {
                        var scopedService = scope.ServiceProvider;
                        //var db = scopedService.GetRequiredService<Context>();
                        var logger = scopedService.GetRequiredService<ILogger<TestsWithWebHostBuilder>>();
                    }

                    services.AddScoped<Iintegra, MyIntegra>();
                });
            })
                .CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false, BaseAddress = new Uri("https://localhost:44356") });


            var defaultpaged = await client.GetAsync("/Integration/Index");
            var contentd = defaultpaged.Content.ReadAsStringAsync().Result;

            Assert.Equal(HttpStatusCode.OK, defaultpaged.StatusCode);
            Assert.Contains("nevelikapoterya", contentd);




            var defaultpage = await client.GetAsync("/Cart/Work2309");
            var content = defaultpage.Content.ReadAsStringAsync().Result;

            Assert.Equal(HttpStatusCode.OK, defaultpage.StatusCode);
            Assert.Contains("Popkorn", content);




            var response = await client.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(client.BaseAddress + "Cart/Work2309")
            });
            var otvet = response.Content.ReadAsStringAsync().Result;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("Popkorn", otvet);
        }


    }
}
