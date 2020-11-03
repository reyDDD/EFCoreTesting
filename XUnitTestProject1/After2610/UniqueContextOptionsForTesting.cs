using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using EFCoreTesting.Models;
using System.Linq;
using System.Threading.Tasks;

namespace XUnitTestProject1.After2610
{
    public class UniqueContextOptionsForTesting
    {
        public static DbContextOptions<Context> OptionsForContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase("MyBase")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options; 

        }
    }
}
