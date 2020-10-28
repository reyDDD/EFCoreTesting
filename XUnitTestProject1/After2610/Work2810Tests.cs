using EFCoreTesting.Controllers.After2510;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.After2610
{
    public class Work2810Tests
    {
        [Fact]
        public void TestingWork2810()
        {
            Work2810Controller controller = new Work2810Controller();

            var model = new Model2810 { Id = 3, Name = "Ivan", PriceBlack = "12,45" };
            var actionResult = controller.Index(model);

            var res = Assert.IsType<ViewResult>(actionResult);
        }
    }
}
