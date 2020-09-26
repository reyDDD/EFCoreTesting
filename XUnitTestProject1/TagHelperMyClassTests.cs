using EFCoreTesting.Infrastructure.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class TagHelperMyClassTests
    {


        [Fact]
        public void TestingMyClassTaghelper()
        {
            //подготовка
            var context = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "uniqueId");
            var output = new TagHelperOutput("div", new TagHelperAttributeList(), (cache, encoder) => System.Threading.Tasks.Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

            ViewContext viewContext = new ViewContext();
            viewContext.RouteData = new Microsoft.AspNetCore.Routing.RouteData();
            viewContext.RouteData.Values.Add("action", "Act");
            viewContext.RouteData.Values.Add("controller", "Cont");

            //действие
            var tagHelper = new MyClassTagHelper() { NewClass = "info" };
            tagHelper.Process(context, output);

            //утверждение
            Assert.Equal($"<div class=\"bg-success\"><p>добавка перед основным содержимым: </p></div>", output.PreElement.GetContent());
        }
    }
}
