using EFCoreTesting.Infrastructure.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class SimpleTagHelperTest
    {

        [Fact]
        public void TaghelperSimpleTest()
        {
            var output = new TagHelperOutput("li", new TagHelperAttributeList(), (cashe, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

            var context = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "uniqueId");

            Help2510 help2510 = new Help2510();
            help2510.Process(context, output);

            Assert.Equal("null in menulist", output.Content.GetContent());
            Assert.Equal("li", output.TagName);
        }

    }
}
