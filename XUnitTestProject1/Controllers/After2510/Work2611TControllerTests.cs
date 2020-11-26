using EFCoreTesting.Controllers.After2510;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1.Controllers.After2510
{
    public class Work2611TControllerTests
    {

        [Fact]
        public void ReturnComponentTest()
        {
            Work2611Controller controller = new Work2611Controller();
            var res = controller.ReturnComponent();

            var d = Assert.IsType<ViewComponentResult>(res);
            Assert.Equal("{ Name = Из компонента вызов в виде возвращаемого значения метода }", d.Arguments.ToString());
        }
    }
}
