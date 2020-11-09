using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Areas.Work.Controllers
{
    [Area("Work")]
    public class Work0911Controller : Controller
    {
        public IActionResult Index()
        {
            return View("with area" as object);
        }
    }
}
