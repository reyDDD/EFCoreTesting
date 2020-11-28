using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2811
{
    public class Work2811Controller : Controller
    {
        private Model2811 model;
        public Work2811Controller(IOptions<Model2811> options)
        {
            model = options.Value;
        }
        public IActionResult Index()
        {
            return View("Index", $"текст тут: {model.Good} {model.Better} {model.TheBest}");
        }
    }
}
