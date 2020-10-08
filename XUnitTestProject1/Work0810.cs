using EFCoreTesting.Components;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class Work0810a
    {
        [Fact]
        public void TestComponentWork0810()
        {
            Work0810 work0810 = new Work0810();
            var res = work0810.Invoke("отак-то") as ViewViewComponentResult;
            Assert.IsType<string>(res.ViewData.Model);
            Assert.Equal("отак-то прибавка к жалованию", res.ViewData.Model);
        }
    }
}
