using Microsoft.AspNetCore.Mvc.Rendering;
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
                output.TagName = "button";
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Attributes.SetAttribute("class", $"btn btn-{ButtonClass}");
                output.Content.SetContent("содержимое тегхелпера");
                output.Content.AppendHtml(" <b>добавочный текст</b>");

                //для вставки элемента до или после output нужно создать элемент с помощью tagBuilder

                TagBuilder container = new TagBuilder("div");
                container.Attributes["class"] = "bg-info m-1 p-1";
                container.InnerHtml.Append("Текст в пре элементе");
                output.PreElement.SetHtmlContent(container);

                //для вставки контента до или после содержимого output создавать элемент не нужно
                output.PreContent.SetHtmlContent("<i>");
                output.PostContent.SetHtmlContent("</i>");
            }
        }
    }
}
