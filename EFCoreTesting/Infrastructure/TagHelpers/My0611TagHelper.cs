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
    [HtmlTargetElement("put", Attributes= "yestTakoy", ParentTag = "div", TagStructure = TagStructure.WithoutEndTag)]
    public class My0611TagHelper : TagHelper
    {
        private IService3110 service;

        public My0611TagHelper(IService3110 service)
        {
            this.service = service;
        }

        [ViewContext]
        public ViewContext ContextData { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.AppendHtml($"<em>здесь был Вася</em> - {service.ReturnName()} : {ContextData.RouteData.Values["action"]}");

        }
    }
}
