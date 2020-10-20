using EFCoreTesting.Controllers;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class Work2010ApiTests : Context2010
    {
        public Work2010ApiTests() : base(new DbContextOptionsBuilder<Context>().UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database=EFCoreTests;Trusted_Connection=True;MultipleActiveResultSets=True;App=EntityFramework;").Options)
        {
        }

        [Fact]
        public async Task ReturnUserFromIdTest()
        {
            ApiWork2010Controller controller = new ApiWork2010Controller(new Context(ContextOptions));

            var res = await controller.ReurnUser(22);

            var user = Assert.IsType<ActionResult<User>>(res);
            Assert.True(user.Value.Id == 22);
        }
    }
}
