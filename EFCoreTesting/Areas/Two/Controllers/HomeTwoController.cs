using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Areas.Two.Controllers
{
    [Area("Two")]
    public class HomeTwoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
