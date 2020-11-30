using EFCoreTesting.Models.After3011;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2811
{
    public class Work3011Controller : Controller
    {
        public IActionResult Index()
        {
            Model3011 model = new Model3011();
            IEnumerable<string> res = model.GetList();
            return View(res);
        }

        public IActionResult Index2()
        {
            string nazvaPeremennoy = "nevazno";
            return View("Stroca", nameof(nazvaPeremennoy));
        }
        public IActionResult Index3()
        {
            string nazvaPeremennoy = null;
            return View("Stroca", this.RetNull2()?.Replace("i", " ") ?? "na");
        }

        
    }
    public static class Vn
    {
        public static string? RetNull2(this Work3011Controller controller)
        {
            return null;
        }
    }
}
