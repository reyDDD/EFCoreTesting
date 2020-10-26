using EFCoreTesting.Controllers.After2510;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.After2610
{
    public class Work2510UniqueContextTests
    {

        [Fact]
        public async void GetIdTests_ReturnData()
        {
            var context = new Context2510(new DbContextOptionsBuilder<Context2510>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFCoreTests;Trusted_Connection=True;MultipleActiveResultSets=True;App=EntityFramework;").Options);
            var repo = new Work2510ModelRepo2(context);
            var controller = new Work2510UniqueContextController(repo);

            var result = await controller.Index(22);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<User>(viewResult.ViewData.Model); //проверка на этот или производный тип
            var model = Assert.IsType<User>(viewResult.ViewData.Model); //проверка, что принадлежит именно этому типу, но не производному
            Assert.Equal("Ворошилов", model.LastName);
        }


        [Fact]
        public async void GetIdTests_ReturnNotFound()
        {
            var context = new Context2510(new DbContextOptionsBuilder<Context2510>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFCoreTests;Trusted_Connection=True;MultipleActiveResultSets=True;App=EntityFramework;").Options);
            var repo = new Work2510ModelRepo2(context);
            var controller = new Work2510UniqueContextController(repo);

            var result = await controller.Index(10000);

            var viewResult = Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public async void GetIdTests_ReturnNBadRequest()
        {
            var context = new Context2510(new DbContextOptionsBuilder<Context2510>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFCoreTests;Trusted_Connection=True;MultipleActiveResultSets=True;App=EntityFramework;").Options);
            var repo = new Work2510ModelRepo2(context);
            var controller = new Work2510UniqueContextController(repo);

            var result = await controller.Index2(new User { FirstName = "fdf" });

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequest.Value);
        }


        [Fact]
        public async void GetIdTests_WorkMethodTrue()
        {
            var user = new User { Id = 22, FirstName = "Malchik", LastName = "", Age = 22, IsMale = true, BirthDay = DateTime.Now, AddressId = 3 };

            var repo = new Mock<IWork2510ModelRepo2>();

            repo.Setup( m =>  m.GetUser(It.IsAny<long>())).ReturnsAsync(user).Verifiable();

            var controller = new Work2510UniqueContextController(repo.Object);


            var result = await controller.Index2(user);

            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            var model = Assert.IsType<User>(viewResult.ViewData.Model);
            Assert.Equal(22, model.Age);
            repo.Verify();
        }

        [Fact]
        public async void GetId_NullUser_ReturnNotFound()
        {
            var user = new User { Id = 22, FirstName = "Malchik", LastName = "", Age = 22, IsMale = true, BirthDay = DateTime.Now, AddressId = 3 };

            var repo = new Mock<IWork2510ModelRepo2>();

            repo.Setup(m => m.GetUser(It.IsAny<long>())).ReturnsAsync((User)null);

            var controller = new Work2510UniqueContextController(repo.Object);


            var result = await controller.Index2(user);

            var viewResult = Assert.IsType<NotFoundResult>(result);
        }
    }
}
