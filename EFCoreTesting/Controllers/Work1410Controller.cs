using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class Work1410Controller : Controller
    {
        public IActionResult Index()
        {
            return new StatusCodeResult((int)HttpStatusCode.NotFound);
        }
    }
}
