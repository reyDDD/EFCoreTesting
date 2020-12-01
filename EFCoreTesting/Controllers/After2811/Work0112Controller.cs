using EFCoreTesting.Models.Chain0112;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2811
{
    public class Work0112Controller : Controller
    {
        public IActionResult Index(string data)
        {
            Original original = new Original();
            string res = original.Zamostit(data);
            return View("Index", res);
        }

        public IActionResult Index2()
        {
            Original original = new Original();
            string res = original.Zamostit2("data");
            return View("Index", res);
        }

        public IActionResult Index3()
        {
 
            return View("Index", "data");
        }
    }
}
