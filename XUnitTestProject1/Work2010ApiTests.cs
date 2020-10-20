using EFCoreTesting.Controllers;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
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

            var user = Assert.IsType<ActionResult<ApiWork2010Controller.Userec>>(res);
            Assert.True(user.Value.Id == 22);
        }


        [Fact]
        public async Task AddUserTest()
        {


            var co = new Context(ContextOptions);
            DbConnection con = co.Database.GetDbConnection();
            con.Open();

            using (var transact = con.BeginTransaction())
            {
                ApiWork2010Controller controller = new ApiWork2010Controller(co);
                controller.connect.Database.UseTransaction(transact);

                ActionResult<User> res = await controller.AddNewUser(3, new User { FirstName = "Lentay", LastName = "Petrovich", Age = 32, IsMale = true });

                var ress = await co.Users.Where(i => i.FirstName == "Lentay" && i.LastName == "Petrovich").Select(i => i.Id).FirstOrDefaultAsync();
                Assert.True(ress > 0);

                //transact.Commit();
                transact.Rollback();
            }
        }


        [Fact]
        public async Task UpdateUserTest()
        {
            ApiWork2010Controller controller = new ApiWork2010Controller(new Context(ContextOptions));
            User ussr = new User { Id = 35, FirstName = "Alex", LastName = "Krilofff", Age = 55, IsMale = true, BirthDay = new DateTime(2002, 12, 30, 0, 0, 0), AddressId = 3, Address = controller.connect.Addresses.Find(3) };

            try
            {
                var res = await controller.UpdateUser(35, ussr);

            }
            catch (Exception ex)
            {
                Assert.True(true);
            }


            var result = controller.connect.Users.Where(i => i.Id == ussr.Id && i.FirstName == ussr.FirstName && i.LastName == ussr.LastName && i.IsMale == ussr.IsMale).FirstOrDefault();
            Assert.True(result != null);
        }

        [Fact]
        public async void RemoveUser()
        {

            var co = new Context(ContextOptions);
            DbConnection con = co.Database.GetDbConnection();
            con.Open();

            using (var transact = con.BeginTransaction())
            {
                ApiWork2010Controller controller = new ApiWork2010Controller(co);
                controller.connect.Database.UseTransaction(transact);

                ActionResult<User> res = await controller.DeleteUser(1000);
                Assert.IsType<NotFoundResult>(res.Result);


                ActionResult<User> res2 = await controller.DeleteUser(42);
                Assert.IsType<ActionResult<User>>(res2);

                //transact.Commit();
                transact.Rollback();
            }

 

            
        }
    }
}
