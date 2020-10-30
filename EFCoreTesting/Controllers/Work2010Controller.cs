using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace EFCoreTesting.Controllers
{

    public class YaPlakalKogdaSmotrel : Attribute, IRouteTemplateProvider
    {
        public string Name => "estTakoy";

        public int? Order => 2;

        public string Template => "otkudaOnVsyalsya";
    }

    [YaPlakalKogdaSmotrel]
    public class Work2010Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("privet/{name}")]
        [Route("[action]/{name}")]
        [HttpGet("[controller]/[action]/{name}")]
        public IActionResult IndexPoydet(string name)
        {
            return View("Index");
        }

    }
}
