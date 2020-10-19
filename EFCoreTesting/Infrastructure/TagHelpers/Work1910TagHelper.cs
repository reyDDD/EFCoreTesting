using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.TagHelpers
{
    [HtmlTargetElement("chto", Attributes = "propa")]
    public class Work1910TagHelper : TagHelper
    {

        public string Propa { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";
            output.Attributes.Add("class", $"btn btn-success {Propa}");
            output.Content.Append("внутренний текст из хелпера");
        }
    }
}
