using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Arey.Controllers
{
    public class AreyOneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
