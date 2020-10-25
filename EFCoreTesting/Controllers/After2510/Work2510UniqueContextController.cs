using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work2510UniqueContextController : Controller
    {
        private Work2510ModelRepo2 modelRepo2;
        public Work2510UniqueContextController(Work2510ModelRepo2 modelRepo2)
        {
            this.modelRepo2 = modelRepo2;
        }
        public async Task< IActionResult> Index(int id)
        {
            var res = await modelRepo2.GetUser(id);
            return View(res);
        }
    }
}
