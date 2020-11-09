using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Areas.Work.Controllers
{
    [Area("Work")]
    public class Work0911Controller : Controller
    {
        public async Task<ActionResult<string>> Index([FromServices] IVozvrat2909 vozvrat)
        {
            var addr = await vozvrat.GetAddress();
            var spisok = addr.ToList().FirstOrDefault();
            return View("Index", "with area+" + " " + spisok.City);
        }
    }
}
