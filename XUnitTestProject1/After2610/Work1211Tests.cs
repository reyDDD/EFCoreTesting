using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Xunit;
using EFCoreTesting.Areas.Distribute.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestProject1.After2610
{
    public class Work1211Tests
    {
        private Context context;
        public Work1211Tests()
        {
            var connString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<Context>().UseSqlServer(connString).Options;
            context = new Context(options);
        }


        [Fact]
        public async Task UpdateUserSuccess()
        {
            //Arrange
            string baseName = "Lastname1211";
            string newName = "NewLastName1211";
            var user = new User() { FirstName = "Name1211", LastName = baseName, Age = 23, BirthDay = new DateTime(year: 2010, month: 12, day: 16), IsMale = true, AddressId = 3 };
            Work1211Controller work1211 = new Work1211Controller(context);

            var userecInBase = await context.Users.FirstOrDefaultAsync(x => x.FirstName == "Name1211" && x.LastName == "Lastname1211");

            if (userecInBase == null)
            {
                userecInBase = context.Users.Add(user).Entity;
                context.SaveChanges();
            }

            //Action
            var actionResult = work1211.Index(userecInBase.Id, newName);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(actionResult);
            var model = Assert.IsType<User>(viewResult.ViewData.Model);
            Assert.Equal(model.LastName, newName);

           work1211.Index(userecInBase.Id, baseName); //возвращаю в исходное состояние
        }
    }
}
