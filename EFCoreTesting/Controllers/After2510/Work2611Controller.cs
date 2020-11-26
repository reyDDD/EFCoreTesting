using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2510
{
    [ViewComponent(Name = "Probny2")]
    public class Work2611Controller : Controller
    {
        public IActionResult Index()
        {
            return View("Index", "faska");
        }

        public IActionResult ReturnComponent()
        {
            return ViewComponent("Probn", new { Name = "Из компонента вызов в виде возвращаемого значения метода" });
        }

        public IViewComponentResult Invoke(string nama)
        {
            return new ViewViewComponentResult() { ViewData = new ViewDataDictionary<string>(ViewData, nama as object)};
        }
    }
}
