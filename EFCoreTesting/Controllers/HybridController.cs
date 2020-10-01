using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        public IActionResult Index(My my)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return View("ogogo" as object);
        }


        public class My
        {
            [Required]
            public string ForError { get; set; }
        }

        public IViewComponentResult Invoke(string text)
        {
            return new ViewViewComponentResult() { ViewData = new ViewDataDictionary<string>(ViewData, text) };
        }
    }
}
