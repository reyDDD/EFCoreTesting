using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTests.After2610.TestDeleteWithIndependentContext
{
    public class ConnToMemory
    {
        //первым шагом создаю DbContextOptions 
        public DbContextOptions<Context> Createoptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase("InMemoryDb")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        //вторым шагом создаю соединение
        public async Task<Context> GetContext()
        {
            Context context = new Context(Createoptions());
            await Seed(context);
            return context;
        }

        //третьим шагом выполняю начальное заполнение базы данных
        public async Task Seed(Context context)
        {
            await context.Addresses.AddAsync(new Address { City = "Киев", Country = "Украина" });
            await context.Users.AddRangeAsync(new List<User>
            {
                new User{FirstName = "Иван", LastName = "Иванов", Age = 22, IsMale = true, BirthDay = DateTime.Now, AddressId = 1},
                 new User{FirstName = "Петр", LastName = "Петров", Age = 33, IsMale = true, BirthDay = DateTime.Now, AddressId = 1},
                  new User{FirstName = "Анастасия", LastName = "Анастасьева", Age = 44, IsMale = false, BirthDay = DateTime.Now, AddressId = 1}
            });
            await context.SaveChangesAsync();
        }
    }
}
