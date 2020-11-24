using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work2411Controller : Controller
    {
        private ForTestConfig2411 options;
        public Work2411Controller(IOptions<ForTestConfig2411> options)
        {
            this.options = options.Value;
        }

        public IActionResult Index()
        {
            return Ok($"{options.FirstParam2} {options.SecondParam2} {options.ThirdParam2}");
        }
    }
}
