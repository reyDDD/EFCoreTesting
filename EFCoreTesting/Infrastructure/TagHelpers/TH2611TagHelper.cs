using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.TagHelpers
{
    [HtmlTargetElement("gg" , Attributes = "namee")]
    public class TH2611TagHelper : TagHelper
    {
        [HtmlAttributeName("namee")]
        public string Namee { get; set; }
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content = await output.GetChildContentAsync();
            output.Content.Append($" yet slowly {Namee}");
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "p";
        }
    }
}
