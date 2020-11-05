using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.TagHelpers
{
    [HtmlTargetElement("li", Attributes = "nachalo*")]
    public class TagHelper0511 : TagHelper
    {
        public string NachaloKonca { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "li";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.Append(NachaloKonca);
            output.Attributes.Add("class", "danger");
        }
    }
}
