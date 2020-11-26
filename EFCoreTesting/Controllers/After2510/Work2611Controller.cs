using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2510
{
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
    }
}
