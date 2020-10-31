using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Areas.Two.Controllers
{
    [Area("Two")]
    public class HomeTwoController : Controller
    {
        public IActionResult Index([FromServices] IService3110 service)
        {
            return View("Index", service.ReturnName());
        }
    }
}
