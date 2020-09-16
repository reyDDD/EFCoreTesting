using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class ValueTuplesController : Controller
    {

        public ActionResult<(int Age, string Name)> Tup(bool bo = true)
        {
            if (bo)
            {
                var corteg = new { Age = 35, Name = "Ivan" };
                return View("Index", (corteg.Age, corteg.Name));
            }

            return View("Index", (Age: 15, Name: "Masha"));
        }

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
