using EFCoreTesting.Controllers.After2811;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1.Controllers.After2811
{
   public class Work2811ControllerTests
    {
        [Fact]
        public void TestOptions()
        {
            var options = Options.Create(new Model2811() { Good = "Good", Better = "Better", TheBest = "TheBest" });
            Work2811Controller controller = new Work2811Controller(options);
            var actionResult = controller.Index();
            var viewResult = Assert.IsType<ViewResult>(actionResult);
            var data = Assert.IsType<string>(viewResult.ViewData.Model);
            Assert.Equal("текст тут: Good Better TheBest", data);
        }
    }
}
