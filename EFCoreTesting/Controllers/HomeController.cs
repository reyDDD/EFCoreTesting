using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Blazor()
        {
            return View("_Host2");
        }
    }
}
