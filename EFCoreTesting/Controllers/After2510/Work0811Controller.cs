using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
 
    public class Work0811Controller : Controller
    {
        [HttpGet("bb")]
        [HttpGet("[controller]/[action]/{name}")]
        //[HttpGet("{name}")]
        public IActionResult Index(int name)
        {
            double meal_cost = 15.50;

            int tip_percent = 15;

            int tax_percent = 10;

            int result = Convert.ToInt32(Math.Round(meal_cost / 100 * tip_percent + meal_cost / 100 * tax_percent + meal_cost));
            return View(result as object);
        }
    }
}
