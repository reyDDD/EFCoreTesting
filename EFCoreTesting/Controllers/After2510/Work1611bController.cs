using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    [Work1611Attribute]
    public class Work1611bController : Controller
    {
        public IActionResult Index()
        {
            return View("This have worked" as object);
        }
    }
}
