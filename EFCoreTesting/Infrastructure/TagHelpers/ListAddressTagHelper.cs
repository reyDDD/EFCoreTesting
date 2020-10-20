using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.TagHelpers
{
    [HtmlTargetElement("returnListAddress")]
    public class ListAddressTagHelper : TagHelper
    {
        private Work2809 work2809;
        public ListAddressTagHelper(Work2809 work2809)
        {
            this.work2809 = work2809;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var adres = GetAddress();
            output.TagName = "ul";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.AppendHtml($"<li>{adres.Id}</li>");
            output.Content.AppendHtml($"<li>{adres.City}</li>");
            output.Content.AppendHtml($"<li>{adres.Country}</li>");
        }


        private Address GetAddress()
        {
            return work2809.GetAddressWithUser();
        }
    }
}
