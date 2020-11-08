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

        public IActionResult Index2()
        {
            decimal positive = Convert.ToDecimal(2) / Convert.ToDecimal(5);
            decimal negative = 7.6565m;
            string result = positive.ToString("F" + 5);
            string result2 = negative.ToString("F" + 5);
            return View();
        }

    }
}
