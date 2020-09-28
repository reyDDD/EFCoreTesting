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
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    var res = context.Users.ToListAsync().Result;
                    Assert.True("Ариэль" == res[0].FirstName);
                }
            }
        }

        [Fact]
        public void TestServiceWithContext()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                var serv = new Work2809(Fixture.CreateContext(transaction));
                serv.AddUser("Ivan", "Pokryskin", 23);
                var res = serv.GetAddressWithUser();

                string name = res.Users.Where(i=> i.FirstName == "Ivan" & i.LastName== "Pokryskin").FirstOrDefault()?.FirstName;
                Assert.True("Ivan" == name);
                //transaction.Commit();
            }

            using (Work2809 serv = new Work2809(Fixture.CreateContext()))
            {
                var res = serv.GetAddressWithUser();
                string name = res.Users.Where(i => i.FirstName == "Ivan" & i.LastName == "Pokryskin").FirstOrDefault()?.FirstName;
                Assert.False("Ivan" == name);
            }
        }

        [Fact]
        public void TestControllerWithContext()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                var serv = new Work2809(Fixture.CreateContext(transaction));
                var controller = new Work2809Controller(serv);
                var adress = (controller.Index() as ViewResult).ViewData.Model as Address;
               

                Assert.Equal("Ivan", adress.Users.First().FirstName);
            }
        }

    }
}
