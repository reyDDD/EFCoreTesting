using EFCoreTesting.Areas.Work.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.After2610
{
   public class Work0911Tests
    {
        private IConfiguration configuration;
        public Work0911Tests()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("two.json").Build();
        }

        [Fact]
        public async void TestCofigData()
        {
            var options = Options.Create<Uzzer2>(new Uzzer2 { Age = "Age", Unique = "Uniquesss", User = "usereces" });
            Work0911Controller work0911Controller = new Work0911Controller(configuration);
            var actionResult = await work0911Controller.Read(options);
            var data = Assert.IsType<ViewResult>(actionResult);
            var model = data.ViewData.Model;
            Assert.Equal("usereces Age Uniquesss", model);
        }
    }
}
