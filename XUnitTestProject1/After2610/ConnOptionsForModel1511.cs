using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject1.After2610
{
    public static class ConnOptionsForModel1511
    {
        public static DbContextOptions<T> GetOptions<T>() where T : DbContext
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<T>()
                .UseInMemoryDatabase("my1511");

            return builder.Options;
        }


        public static void AddNewUserToInMemoryDataBase(DbContext context)
        {
            User user = new User() { FirstName = "Name1511", LastName = "LastName1511", Age = 12, BirthDay = new DateTime(year: 2010, month: 12, day: 16), IsMale = true, AddressId = 3 };
            context.Entry(user).State = EntityState.Added;
            User user2 = new User() { FirstName = "Name1511-2", LastName = "LastName1511-2", Age = 23, BirthDay = new DateTime(year: 2010, month: 12, day: 16), IsMale = true, AddressId = 3 };
            context.Entry(user2).State = EntityState.Added;
            context.SaveChanges();
        }
    }
}
