﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

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

        public IActionResult FromSectionConfigure([FromServices] IOptions<MySectionData> options)
        {
            MySectionData ret = new MySectionData();
            try
            {
                ret = options.Value;
            }
            catch (Exception ex)
            {
                ret.Age = "Unknown";
                ret.User = $"{ex.Message}";
            }
            return View("Index", $"{ret?.User} {ret?.Age}");
        }

        public class MySectionData
        {
            [StringLength(12, MinimumLength = 10)]
            public string User { get; set; }
            public string Age { get; set; }
        }


        [HttpPost]
        public IActionResult UpdateCity([FromServices] Service1611 service, int id, string city)
        {
            if (id == 0) return BadRequest($"{id} not input");
           Address adress = service.UpdateCity(id, city);

            return View("Index", $"{adress.City} {adress.Country}");
        }
    }
}
