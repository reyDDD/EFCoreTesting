using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public class GetContextFromIServiceProvider
    {
        public Context ReturnContext(IServiceProvider serviceProvider)
        {
            var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>());
            return context;
        }

        public async Task<Address> ReturnDataFromBase(Context context)
        {
            return await context.Addresses.FirstOrDefaultAsync();
        }

    }
}
