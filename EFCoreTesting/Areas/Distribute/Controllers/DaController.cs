using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class DaController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", new TwoData { Data1 = DateTime.Now, Data2 = DateTime.Now });
        }


        public IActionResult IndexBind([Bind("FirstName,LastName")]User user)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
            return View("IndexBind");
        }
    }
}
