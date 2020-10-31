using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EFCoreTesting.Areas.Two.Controllers
{
    [Area("Two")]
    public class HomeThreeController : Controller
    {
        private readonly Uzver options;

        public HomeThreeController(IOptions<Uzver> options)
        {
            this.options = options.Value;
        }
        public IActionResult Index()
        {
            return View("Index", options.User + " " + options.Age);
        }
    }
}
