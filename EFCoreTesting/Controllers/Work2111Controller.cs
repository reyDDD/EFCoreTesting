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
    }
}
