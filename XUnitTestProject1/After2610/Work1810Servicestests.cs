using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.After2610
{
    public class Work1810Servicestests
    {
        private Context context;
        public Work1810Servicestests()
        {
            var connString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
            context = new Context(new DbContextOptionsBuilder<Context>().UseInMemoryDatabase("ff").Options);
        }

        [Fact]
        public void TestReturnNull()
        {
            var mock = new Mock<IWork1810Service>();
            mock.Setup(x => x.ReturAddressFirst()).Returns((Address)null!);
            IWork1810Service service = mock.Object;
            var res = service.ReturAddressFirst();
            Assert.Null(res);
        }
    }
}
