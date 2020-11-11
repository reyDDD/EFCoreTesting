using EFCoreTesting.Areas.Distribute.Controllers;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.After2610
{
  public  class Work1111Tests : IDisposable
    {
        private Context context;
        private IConfiguration config;

        public Work1111Tests()
        {
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            context = new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(config.GetSection("ConnectionStrings:DefaultConnection").Value).Options);
        }

        [Fact]
        public void TestMethodAdd()
        {
            var user = new User() { FirstName = "Ivan", LastName = "Oboltus", Age = 23, BirthDay = new DateTime(year: 2010, month: 12, day: 16), IsMale = true, AddressId = 3 };
            Work1111Controller controller = new Work1111Controller(context);
 
                var actionResult = controller.Add(user);
                var model = Assert.IsType<OkObjectResult>(actionResult);
                var data = Assert.IsType<string>(model.Value.ToString());
                Assert.Equal("Ivan", data);
 
            
        }

        public void Dispose()
        {

            context.Dispose();
      
        }

      
    }
}
