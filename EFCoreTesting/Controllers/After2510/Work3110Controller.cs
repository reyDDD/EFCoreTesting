using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work3110Controller : Controller
    {
        private readonly ForTestCongigOptions settings;

        public Work3110Controller(IOptions<ForTestCongigOptions> settingsOptions)
        {
            settings = settingsOptions.Value;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = settings.FirstParam;
            ViewData["Updates"] = settings.SecondParam;

            return View();
        }
    }
}
