using EFCoreTesting.Infrastructure.TagHelpers;
using EFCoreTesting.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.After2610
{
    public class My0611TagHelperTest
    {

        [Fact]
        public void TestViewContext()
        {
            Service3110 service3110 = new Service3110();

            My0611TagHelper help = new My0611TagHelper(service3110);
            var res = help.ContextData.RouteData.Values["action"].ToString();
            Assert.True(res != null);
        }
    }
}
