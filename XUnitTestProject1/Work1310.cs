using EFCoreTesting.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestProject1
{
    public class Work1310 : IClassFixture<WebApplicationFactory<EFCoreTesting.Startup>>
    {
        private readonly WebApplicationFactory<EFCoreTesting.Startup> factory;

        public Work1310(WebApplicationFactory<EFCoreTesting.Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async void TestAddressContainsElemets()
        {
            var client = factory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false, BaseAddress = new Uri("https://localhost:44356") });

            var defaultpaged = await client.GetAsync("/Work1310/Index");
            var contentd = defaultpaged.Content.ReadAsStringAsync().Result;

            Assert.False((contentd.Contains("The base contains null elements Address")));

            //мораль сей басни такова - для тестов используй нормальное создание экземляра DB через DI
        }
    }
}
