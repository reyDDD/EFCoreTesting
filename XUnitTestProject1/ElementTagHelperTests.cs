using EFCoreTesting.Infrastructure.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class ElementTagHelperTests
    {
        [Fact]
        public void TestElemetaryHelper()
        {
            //организация
            var context = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(),
                "myuniqueId");

            var output = new TagHelperOutput("div", new TagHelperAttributeList(), (cache, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

            //действие
            var tagHelper = new Elementary() { Name = "malenyko" };
            tagHelper.Process(context, output);

            //утверждение
            Assert.Equal($"{tagHelper.Name}", output.Attributes["namedatut"].Value);

        }
    }
}
