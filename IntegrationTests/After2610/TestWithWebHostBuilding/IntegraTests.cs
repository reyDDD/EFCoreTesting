using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests.After2610.TestWithWebHostBuilding
{
    public class IntegraTests : IClassFixture<CustomWebApplicationFactory<EFCoreTesting.Startup>>
    {
        private CustomWebApplicationFactory<EFCoreTesting.Startup> factory;
        public IntegraTests(CustomWebApplicationFactory<EFCoreTesting.Startup> factory)
        {
            this.factory = factory;
        }


        [Fact]
        public async Task TestWithSettingsServices()
        {
            var client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var serviceProvider = services.BuildServiceProvider();

                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices.GetRequiredService<Context>();

                        try
                        {
                            db.Users.Add(new User { FirstName = "Duben", LastName = "Dubinin", Age = 22, BirthDay = DateTime.Now, IsMale = true, AddressId = 3 });
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                });
            }).CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });


            var defaultPage = await client.GetAsync("/Work2510UniqueContext/GetUserAtData?FirstName=Duben&LastName=Dubinin&Age=22&IsMale=true");

            var html = await defaultPage.Content.ReadAsStringAsync();
            var res = html.Contains("Dubinin");

            Assert.True(res);

            
        }
    }
}
