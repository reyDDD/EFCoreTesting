using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.TagHelpers
{
    [HtmlTargetElement("pp", Attributes = "add-button2")]
    public class AddedClassToRealTagHelper : TagHelper
    {
        [HtmlAttributeName("add-button2")]
        public string AddedClassToReal { get; set; }


        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            //if (output.Attributes.ContainsName("class"))
            //{
            //    string addedClassForButton = "btn btn-success";
            //    addedClassForButton = $"{addedClassForButton} {output.Attributes["class"].Value}";
            //    output.Attributes.SetAttribute("class", addedClassForButton);
            //}
            output.Attributes.AddAlimetsToClass("btn btn-success2");
            output.TagName = "p";
            output.TagMode = TagMode.StartTagAndEndTag;
           output.Content = await output.GetChildContentAsync();
            output.Content.Append(" plus");
            output.Content.AppendHtml("<i> minus</i>");
        }
    }

    public static class AddPrefixClass
    {
        public static void AddAlimetsToClass(this TagHelperAttributeList attributes, string newClassValue)
        {
            if (attributes.ContainsName("class"))
            {
                newClassValue = $"{newClassValue} {attributes["class"].Value}";
                attributes.SetAttribute("class", newClassValue);
            }
        }
    }
}
