using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class Work1610Controller : Controller
    {
        public IActionResult Index(ModelForCheck modelec)
        {
            if (ModelState.IsValid)
            {
                return View(modelec);
            }
            return View();
        }
    }
}
