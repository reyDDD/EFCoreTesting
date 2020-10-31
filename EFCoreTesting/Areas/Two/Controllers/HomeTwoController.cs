using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace EFCoreTesting.Areas.Two.Controllers
{

    public class Uzver
    {
        public readonly string nameConf = "Юзверь";
        [MinLength(15)]
        [StringLength(16)]
        public string User { get; set; }
        public string Age { get; set; }
    }


    [Area("Two")]
    public class HomeTwoController : Controller
    {
        private readonly IConfiguration Configuration;
        public HomeTwoController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index([FromServices] IService3110 service)
        {
            return View("Index", service.ReturnName());
        }

        public IActionResult Index2()
        {
            var user = Configuration.GetSection("TestSection").Get<Uzver>();
            return View("Index", user.User);
        }

    }
}
