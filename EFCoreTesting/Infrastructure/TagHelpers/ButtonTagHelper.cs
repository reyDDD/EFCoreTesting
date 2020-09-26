using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.TagHelpers
{
    public class ButtonTagHelper : TagHelper
    {
        public string ButtonClass { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ButtonClass != null)
            {
                output.Attributes.SetAttribute("class", $"btn btn-{ButtonClass}");
            }
        }
    }
}
