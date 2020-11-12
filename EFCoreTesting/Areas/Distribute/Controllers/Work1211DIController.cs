using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models.WithParameterForDI;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class Work1211DIController : Controller
    {
        private IDIyes iDIyes;
        public Work1211DIController(IDIyes iDIyes)
        {
            this.iDIyes = iDIyes;
        }
        public IActionResult Index()
        {
            return View("Index", iDIyes.MyProperty.ToString());
        }
    }
}
