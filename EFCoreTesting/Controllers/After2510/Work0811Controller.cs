﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
 
    public class Work0811Controller : Controller
    {
        //[HttpGet("{name}")]
        [HttpGet("[controller]/[action]/{name}")]
        public IActionResult Index(int name)
        {
            return View("dd" as object);
        }
    }
}
