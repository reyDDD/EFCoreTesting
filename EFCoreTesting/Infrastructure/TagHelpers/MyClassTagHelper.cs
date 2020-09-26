using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.TagHelpers
{
    [HtmlTargetElement("myClass", Attributes = "new-class", ParentTag = "div")]
    public class MyClassTagHelper : TagHelper
    {
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContextData { get; set; }

        public string NewClass { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetContent("пользовательский тег хелпер");
            if (NewClass != null)
            {
                output.Attributes.SetAttribute("class", $"bg-{NewClass}");
            }
         
            output.PreContent.SetHtmlContent("<b>");
            output.PostContent.SetHtmlContent("</b>");

            TagBuilder builder = new TagBuilder("div");
            builder.InnerHtml.AppendHtml($"<p>добавка перед основным содержимым: {ViewContextData.RouteData.Values["controller"].ToString()} / {ViewContextData.RouteData.Values["action"].ToString()}</p>");
            builder.Attributes.Add("class", "bg-success");

            output.PreElement.AppendHtml(builder);
        }
    }
}
