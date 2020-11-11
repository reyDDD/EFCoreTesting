using EFCoreTesting.Areas.Distribute.Controllers;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        private Context contextInMemory;

        public Work1111Tests()
        {
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            context = new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(config.GetSection("ConnectionStrings:DefaultConnection").Value).Options);
            contextInMemory = new Context((new DbContextOptionsBuilder<Context>().UseInMemoryDatabase("myBase")).Options);
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

        [Fact]
        public void TestMethodAddForBadRequest()
        {
            var user = new User() { FirstName = "Ivan", LastName = "Oboltus", Age = 23, BirthDay = new DateTime(year: 2010, month: 12, day: 16), IsMale = true, AddressId = 3 };
            Work1111Controller controller = new Work1111Controller(context);
            
            controller.ModelState.AddModelError("key", "исскуственно вызвананя ошибка достоверности модели");
            var actionResult = controller.Add(user);
            var model = Assert.IsType<BadRequestObjectResult>(actionResult);
            Assert.IsType<SerializableError>(model.Value);

            var res = controller.ModelState.Values;
            foreach (var modelState in controller.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    Assert.Equal("исскуственно вызвананя ошибка достоверности модели", error.ErrorMessage);
                }
            }
            
        }



        public void Dispose()
        {
            config = null!;
            context.Dispose();
        }

      
    }
}
