using EFCoreTesting.Controllers.After2510;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitTestProject1.After2610;

namespace XUnitTestProject1.Controllers.After2510
{
   public class Work1611c
    {
        private IConfiguration configuration;
        private Context context;
        public Work1611c()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var address = new Address { City = "Задрюпинск", Country = "Караганда" };
            var serviceProvader = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase("hh")
                .UseInternalServiceProvider(serviceProvader)
                .Options;

            context = new Context(options);
            context.Addresses.Add(address);
        }

        [Theory]
        [InlineData(1, "Конотоп")]
        public void UpdateCity(int id, string name)
        {
            Service1611 service = new Service1611(context);
            Work1611cController controller = new Work1611cController(configuration);
            var actionResult = controller.UpdateCity(service, id, name);
            var viewREsult = Assert.IsType<ViewResult>(actionResult);
            var data = Assert.IsType<string>(viewREsult.ViewData.Model);
            Assert.Equal("Конотоп Караганда", data);

        }
    }
}
