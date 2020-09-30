using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public class ServiceWithAnalogDBContext
    {
        public Context WorkWithContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.development.json")
                .Build();

            var connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;

            var optionBuilder = new DbContextOptionsBuilder<Context>();
            optionBuilder.UseSqlServer(connectionString);
            optionBuilder.UseLoggerFactory(loggerFactory: LoggerFactory.Create(builder => { builder.AddConsole(); }));

            return new Context(optionBuilder.Options);
        }

        public Address GetAddressWithFilterUser(int id)
        {
            var context = WorkWithContext();

            var adr = context.Addresses.Where(i => i.Id == id).First();

            context.Entry(adr).Collection(i => i.Users).Query().Where(x => x.Id > 5).Load();
            return adr;
        }


    }
}
