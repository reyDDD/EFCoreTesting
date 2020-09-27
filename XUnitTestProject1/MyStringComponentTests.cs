using EFCoreTesting.Components;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class MyStringComponentTests
    {

        [Fact]
        public void TestingMyString()
        {
            var myComponent = new MyString();
            var result = myComponent.Invoke() as ViewViewComponentResult;

            Assert.Equal("Строка в ответе", result.ViewData.Model);
            Assert.IsType<string>(result.ViewData.Model);
        }
    }
}
