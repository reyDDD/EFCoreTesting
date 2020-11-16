using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2510
{
    [Route("[controller]/[action]", Name = "[controller]_[action]")]
    public class Work1611Controller : Controller
    {
        [HttpGet]
        [HttpGet("{age}")]
        public IActionResult Index(int age)
        {
            return View(age);
        }
    }
}
