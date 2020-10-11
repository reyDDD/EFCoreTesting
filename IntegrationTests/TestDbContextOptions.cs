using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class TestDbContextOptions
    {
        public static DbContextOptions<Context> CreateOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase("basasa")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}
