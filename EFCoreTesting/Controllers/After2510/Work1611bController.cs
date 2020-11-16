using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    //[Route("nacalo/[controller]/[action]")]
    //[Work1611Attribute]
    public class Work1611bController : Controller
    {
       // [HttpGet(Name = "Otut")]
        [Work1611Attribute]
        public IActionResult Index(string name)
        {
            return View($"This have worked: {name}" as object);
        }

        public IActionResult Index2()
        {
            string url = Url.Action("Index", "Work1611b", new { name = "opachki" });
            return View("Index", url as object);
        }

        public IActionResult Index3()
        {
            string url = Url.RouteUrl("Otut", new { name = "opachki" });
            return View("Index", url);
        }
    }
}
