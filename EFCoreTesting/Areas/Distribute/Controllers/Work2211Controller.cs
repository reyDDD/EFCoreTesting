using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class Work2211Controller : Controller
    {
        public IActionResult Index(int id)
        {
            if (id is 0 )
            {
                return new StatusCodeResult((int)HttpStatusCode.Found);
            }
            return View();
        }
    }
}
