﻿using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers
{
    public class Work2111Controller : Controller
    {
        public IActionResult Index()
        {
            Model2111 model = new Model2111() { Data = DateTime.Now};
            
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public IActionResult Index2(string ofiget)
        {
            var s = ofiget;
            Model2111 model = new Model2111() { Data = DateTime.Now };

            return View("Index", model);
        }

        public IActionResult Index2([Bind("Country, City")] Address adr)
        {
            return View("Index");
        }

    }
}
