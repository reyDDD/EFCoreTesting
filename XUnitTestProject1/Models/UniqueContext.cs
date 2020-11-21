using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestProject1.Models
{
   public static class UniqueContext
    {
        public static Context ReturnContext()
        {
            var provider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            var option = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase("ma").Options;
            return new Context(option);
        }
    }
}
