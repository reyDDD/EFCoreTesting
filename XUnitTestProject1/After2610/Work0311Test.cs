using EFCoreTesting.Controllers.After2510;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.After2610
{
    public class DataConnection
    {
        public string DataConn { get; set; } = string.Empty;
    }

    public class Work0311Test
    {
        private Context context;
        public IConfigurationRoot Config { get; set; }

        public Work0311Test()
        {
            Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            context = new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(Config.GetSection("ConnectionStrings:DefaultConnection").Value).Options);
        }


        [Fact]
        public void TestGetFromDb()
        {
            var user = context.Users.FirstOrDefaultAsync().Result;
            Assert.Equal("Ворошилов", user.LastName);
        }



        [Fact]
        public void TestController()
        {
            var controller = new Work0311Controller();
            var res = controller.Index("hihi");

            var resa = Assert.IsType<ViewResult>(res);
            var data = Assert.IsType<string>(resa.ViewData.Model);
            Assert.Equal("hihi", data);
        }
    }
}
