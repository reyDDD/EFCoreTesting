using EFCoreTesting.Controllers;
using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1.After2610
{
    public class Work2510ControllerTests
    {

        [Fact]
        public async void UpdateUserWithAddress_UnchangeWithTransaction()
        {
            //подготовка
            User user = new User
            {
                FirstName = "Ivanec",
                LastName = "Ivancov",
                Age = 33,
                IsMale = true,
                BirthDay = DateTime.Now,
                AddressId = 3
            };
            var connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
            var context = new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(connectionString).Options);
           


            //реализация
            using (var transaction = context.Database.BeginTransaction())
            {
                Work2510Model work2510Model = new Work2510Model(context);
                Work2510Controller controller = new Work2510Controller(work2510Model);

                await controller.UpdateUserWithAddress2(user);
                var userResult = await context.Users.Where(u => u.FirstName == "Ivanec" && u.LastName == "Ivancov").FirstOrDefaultAsync();
                Assert.True(userResult != null);

                await transaction.RollbackAsync();
            }
            var userResult2 = await context.Users.Where(u => u.FirstName == "Ivanec" && u.LastName == "Ivancov").FirstOrDefaultAsync();

            //проверка
            Assert.True(userResult2 == null);
        }
    }
}
