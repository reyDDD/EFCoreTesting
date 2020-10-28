using EFCoreTesting.Controllers.After2510;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Xunit;

namespace XUnitTestProject1.After2610
{
    public class Api2810Tests : IDisposable
    {
        private Context2510 context;

        public Api2810Tests()
        {
            DbContextOptions<Context2510> options = new DbContextOptionsBuilder<Context2510>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFCoreTests;Trusted_Connection=True;MultipleActiveResultSets=True;App=EntityFramework;").Options;
            this.context = new Context2510(options);
        }

        [Fact]
        public async void TestAddUser()
        {
            Work2510ModelRepo2 repo = new Work2510ModelRepo2(context);

            Api2810Controller controller = new Api2810Controller(repo);
            User user = new User { FirstName = "Ivan", LastName = "Petrov", Age = 33, IsMale = true, BirthDay = DateTime.Now, AddressId = 3 };
            var transaction = await context.Database.BeginTransactionAsync();


            var actionResult = await controller.AddUserAsync(user);
            var result = Assert.IsType<CreatedAtActionResult>(actionResult);
            Assert.Equal("ReturnErrorData", result.ActionName);
            Assert.Equal(201, result.StatusCode);

            await transaction.RollbackAsync();

        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
