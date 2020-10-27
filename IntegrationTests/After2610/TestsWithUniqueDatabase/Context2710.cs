using EFCoreTesting.Models;
using IntegrationTests.After2610.TestDeleteWithIndependentContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTests.After2610.TestsWithUniqueDatabase
{
    public class Context2710
    {
        private static DbContextOptions<Context> TestDbContextoptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase("DataInMemory")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        public  async static Task<Context> ReturnContext()
        {
            var context = new Context(TestDbContextoptions());

            await new ConnToMemory().Seed(context);
            return context;
        }
    }
}
