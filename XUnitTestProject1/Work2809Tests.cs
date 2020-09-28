using EFCoreTesting.Controllers;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestProject1
{
    public class Work2809Tests : IClassFixture<MyWorkContext>
    {
        public MyWorkContext Fixture { get; }

        public Work2809Tests(MyWorkContext fixture)
        {
            Fixture = fixture;
        }




        [Fact]
        public void TestInheritanceContext()
        {
            using (var context = Fixture.CreateContext())
            {
                var res = context.Users.ToListAsync().Result;
                Assert.True("Ариэль" == res[0].FirstName);
            }

        }

        [Fact]
        public void TestServiceWithContext()
        {
            var serv = new Work2809(Fixture.CreateContext());
            var res = serv.GetAddressWithUser();

            string name = res.Users.First().FirstName;
            Assert.True("Ivan" == name);

        }

        [Fact]
        public void TestControllerWithContext()
        {
            var serv = new Work2809(Fixture.CreateContext());
            var controller = new Work2809Controller(serv);
            var adress = (controller.Index() as ViewResult).ViewData.Model as Address;

             
            Assert.Equal("Ivan", adress.Users.First().FirstName);

        }

    }
}
