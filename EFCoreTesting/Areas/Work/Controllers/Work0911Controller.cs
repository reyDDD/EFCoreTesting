using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EFCoreTesting.Areas.Work.Controllers
{

    public class Uzzer
    {
        public string Name { get; set; } = "TestSection3";
        public string User { get; set; }
        public string Age { get; set; }
    }
    [Area("Work")]
    public class Work0911Controller : Controller
    {
        private IConfiguration configuration;
        public Work0911Controller(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<ActionResult<string>> Index([FromServices] IVozvrat2909 vozvrat)
        {
            var addr = await vozvrat.GetAddress();
            var spisok = addr.ToList().FirstOrDefault();
            return View("Index", "with area+" + " " + spisok.City);
        }

        public async Task <ActionResult> GetDataFromConfigaration()
        {
            Uzzer user = new Uzzer();
            configuration.GetSection(user.Name).Bind(user);
            return View("Index", user.User + " " + user.Age);
        }

        public async Task<ActionResult> GetDataFromConfigaration2()
        {
            Uzzer user = new Uzzer();
            Uzzer result = configuration.GetSection(user.Name).Get<Uzzer>();
            return View("Index", result.User + " " + result.Age);
        }
    }
}
