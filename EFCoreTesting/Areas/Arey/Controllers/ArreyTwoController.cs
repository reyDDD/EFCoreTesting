using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Areas.Arey.Controllers
{
    public class ArreyTwoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
