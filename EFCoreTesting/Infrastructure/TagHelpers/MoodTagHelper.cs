using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.TagHelpers
{


    [HtmlTargetElement("boris", ParentTag = "div", Attributes ="hare")]
    [HtmlTargetElement("p", ParentTag = "li")]
    public class MoodTagHelper : TagHelper
    {
        public string Moodak { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "pokatit");
            output.Content.Append(Moodak);
            output.PreContent.SetHtmlContent("<b>контент перед выводом содержимого</b> ");
            output.PostContent.SetHtmlContent("<b> контент после вывода содержимого</b>");
            output.PreElement.SetHtmlContent("<i>элемент перед контентом</i>");
            output.PostElement.SetHtmlContent("<i>элемент после контента</i>");
        }
    }
}
