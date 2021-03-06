﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EFCoreTesting.Areas.Work.Controllers
{
    public class Uzzer2
    {
        public string User { get; set; }
        public string Age { get; set; }
        public string Unique { get; set; }
    }
    public class Uzzer
    {
        public string Name { get; set; } = "TestSection3";
        public string User { get; set; }
        public string Age { get; set; }

        public void Deconstruct(out string name, out string user, out string age) =>
        (name, user, age) = (Name, User, Age);
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


        public async Task<ActionResult> GetDataFromConfigaration3([FromServices] IOptions<Uzzer> option)
        {
            try
            {
                var user = option.Value;
                return View("Index", user.User + " " + user.Age);
            }
            catch (Exception ex )
            {
                return View("Index", ex.Message);
            }
        }


        public async Task<ActionResult> GetDataFromOptions([FromServices] IOptionsSnapshot<Uzzer> option)
        {
            Uzzer user = option.Value;
            return View("Index", user.User + " " + user.Age);
        }

        public async Task<ActionResult> GetDataFromOptions2([FromServices] IOptionsSnapshot<Uzzer> option)
        {
            Uzzer user = option.Get("Section2");
            return View("Index", user.User + " " + user.Age);
        }

        public async Task<ActionResult> Read([FromServices] IOptions<Uzzer2> option)
        {
            Uzzer2 user = option.Value;
            return View("Index", user.User + " " + user.Age + " " + user.Unique);
        }
    }
}
