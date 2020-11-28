using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.TagHelpers
{
    [HtmlTargetElement("factt", Attributes = "maye-buty")]
    public class OriginTakoy : TagHelper
    {
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content = await output.GetChildContentAsync();
            output.Content.Append(" добавка");
            output.TagName = "p";
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
