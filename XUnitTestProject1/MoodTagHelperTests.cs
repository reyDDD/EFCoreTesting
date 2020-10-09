using EFCoreTesting.Infrastructure.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class MoodTagHelperTests
    {
        [Fact]
        public void TestMood()
        {
            var context = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "uniqueId");

            var output = new TagHelperOutput("div", new TagHelperAttributeList(), (cache, encoder) => 
            Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

            var mood = new MoodTagHelper() { Moodak = "good" };
            mood.Process(context, output);

            Assert.Equal("div", output.TagName);
            Assert.Equal("pokatit", output.Attributes["class"].Value);
            Assert.Equal(mood.Moodak, output.Content.GetContent());
        }
    }
}
