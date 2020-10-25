using EFCoreTesting.Components;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class Comp2510Tests
    {
        [Fact]
        public void Test2510Component()
        {
            Comp2510 compon = new Comp2510();

            ViewViewComponentResult? result = compon.Invoke("eys") as ViewViewComponentResult;
            Assert.IsType<String>(result.ViewData.Model);
            Assert.Equal("eys", result.ViewData.Model);
        }
    }
}
