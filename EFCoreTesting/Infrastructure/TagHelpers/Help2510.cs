using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.TagHelpers
{
    [HtmlTargetElement("li", Attributes = "names")]
    public class Help2510 : TagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "li";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.RemoveAll("names");
            output.Content.Append("null in menulist");
        }
    }


    [HtmlTargetElement("li", Attributes = "named, plus")]
    public class Help2510b : TagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.RemoveAll("named");
            output.Content.Append("пустота внутри параграфа");
        }
    }
}
