﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work1611cController : Controller
    {
        private IConfiguration configuration;
        public Work1611cController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            MySectionData mySection = new MySectionData();
            configuration.GetSection("TestSection3").Bind(mySection);
            return View("Index", $"{mySection.User} {mySection.Age}");
        }

        public IActionResult Index2()
        {
            MySectionData mySection = configuration.GetSection("TestSection2").Get<MySectionData>();
            return View("Index", $"{mySection.User} {mySection.Age}");
        }

        public class MySectionData
        {
            public string User { get; set; }
            public string Age { get; set; }
        }
    }
}
