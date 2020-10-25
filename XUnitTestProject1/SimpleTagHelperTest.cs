using EFCoreTesting.Infrastructure.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
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

            Assert.Equal("нулек такой нулёк", output.Content.GetContent(HtmlEncoder.Create(UnicodeRanges.All)));
            Assert.Equal("li", output.TagName);
        }

    }
}
