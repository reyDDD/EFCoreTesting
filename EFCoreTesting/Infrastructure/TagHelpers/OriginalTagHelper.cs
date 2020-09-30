using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.TagHelpers
{
    [HtmlTargetElement("divneprostoy", Attributes = "tut-vam-ne-leto", ParentTag = "div")]
    public class OriginalTagHelper : TagHelper
    {
        public string TutVamNeLeto { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "bg-success");
            output.Content.SetContent($"содержимое пользовательского тега - {TutVamNeLeto}");

            output.PreContent.SetHtmlContent("<i>");
            output.PostContent.SetHtmlContent("</i>");

            var tagBuilder = new TagBuilder("div");
            tagBuilder.Attributes["class"] = "btn btn-info";
            tagBuilder.InnerHtml.AppendHtml("<p>текстовка</p>");

            output.PostElement.SetHtmlContent(tagBuilder);
        }
    }
}
