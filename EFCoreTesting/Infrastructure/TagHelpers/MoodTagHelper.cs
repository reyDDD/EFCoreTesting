using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
        private ComponentBasese componentBasese;

        public MoodTagHelper(ComponentBasese componentBasese) => this.componentBasese = componentBasese;

        public string Moodak { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContextData { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "pokatit");
            output.Content.Append(Moodak);
            output.PreContent.SetHtmlContent("<b>контент перед выводом содержимого</b> ");
            output.PostContent.SetHtmlContent("<b> контент после вывода содержимого</b>");
            output.PreElement.SetHtmlContent($"<i>элемент перед контентом {(ViewContextData.ViewData.Model as Address)?.City}</i>");
            output.PostElement.SetHtmlContent($"<i>элемент после контента {componentBasese.ReturnCount() }</i>");
        }
    }
}
