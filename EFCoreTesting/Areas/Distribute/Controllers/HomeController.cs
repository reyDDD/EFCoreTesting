using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Areas.DistributeCache.Controllers
{


    [Area("Distribute")]
    public class HomeController : Controller
    {
        private T Ret<T>(T x, T y)
        {
            return x;
        }

        public IActionResult Index()
        {
            Ret(3, 6);

            return View();
        }
    }
}
