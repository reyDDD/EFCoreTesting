using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers
{
    [ViewComponent(Name = "Hybrid")]
    public class HybridController : Controller
    {
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 300)]
        public IActionResult Index()
        {
            return View("ogogo" as object);
        }

        public IViewComponentResult Invoke(string text)
        {
            return new ViewViewComponentResult() { ViewData = new ViewDataDictionary<string>(ViewData, text) };
        }
    }
}
