using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.TagHelpers
{
    [HtmlTargetElement("gg", Attributes = "namee", ParentTag = "div", TagStructure = TagStructure.NormalOrSelfClosing)]
    [HtmlTargetElement("gg", Attributes = "namee")]
    public class TH2611TagHelper : TagHelper
    {
        [HtmlAttributeName("namee")]
        public string Namee { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContextData { get; set; }
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content = await output.GetChildContentAsync();
            output.Content.Append($" yet slowly {Namee}");
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "p";
            output.PreElement.SetHtmlContent("<i>ii</i>");
            output.PostContent.SetHtmlContent($" <u>end: {ViewContextData.ViewData.Model.ToString()}</u>");
        }
    }
}
