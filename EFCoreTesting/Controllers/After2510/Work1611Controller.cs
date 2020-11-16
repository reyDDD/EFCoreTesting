using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work1611Controller : Controller
    {
        [HttpGet("{age}")]
        public IActionResult Index(int age)
        {
            return View(age);
        }
    }
}
