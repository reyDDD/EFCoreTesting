using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class Work1311Controller : Controller
    {
        private IConfiguration configuration;

        public Work1311Controller(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        
        public IActionResult Index()
        {
            string res = configuration.GetValue<string>("первый");
            return View("Index", res);
        }
    }
}
