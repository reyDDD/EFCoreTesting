using EFCoreTesting.Infrastructure.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1.Infrastructure.TagHelpers
{
    public class TH2611TagHelperTests
    {
        [Fact]
        public void TagTest()
        {
            var context = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "uniqueId");
            var output = new TagHelperOutput("p", new TagHelperAttributeList(), (cache, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

            TH2611TagHelper tH2611TagHelper = new TH2611TagHelper() { Namee = "forme" };
            tH2611TagHelper.Process(context, output);

            Assert.Equal(" yet slowly forme", output.Content.GetContent());
        }
    }
}
