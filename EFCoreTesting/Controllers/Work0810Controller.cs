using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EFCoreTesting.Controllers
{
    [ViewComponent(Name = "Combo0810")]
    public class Work0810Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IViewComponentResult Invoke()
        {
            return new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<string>(ViewData, "текст для модели")
            };
        }

    }
}
