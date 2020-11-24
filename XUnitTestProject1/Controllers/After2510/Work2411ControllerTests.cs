using EFCoreTesting.Controllers.After2510;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1.Controllers.After2510
{
    public class Work2411ControllerTests
    {
        IOptions<ForTestConfig2411> options;

        public Work2411ControllerTests()
        {
            options = Options.Create(new ForTestConfig2411 { FirstParam2 = "ff", SecondParam2 = "ss", ThirdParam2 = "tt" });
        }

        [Fact]
        public void TestOptions()
        {
            Work2411Controller controller = new Work2411Controller(options);
            var okResult = controller.Index();
            var  data = Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal("ff ss tt", data.Value);
        }
    }
}
