using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class ValueTuplesController : Controller
    {
        public IActionResult Index(int id = 12, string name = "Sarah")
        {
            (int, string) tyr = (id, name);

            (int, string) Test((int, string Name) korteg)
            {
                return (korteg.Item1 + 5, korteg.Name + " add");
            }


            return View("Index", Test(tyr));
        }
    }
}
