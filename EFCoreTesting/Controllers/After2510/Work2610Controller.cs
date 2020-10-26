using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    [ResponseCache(Duration = 30, VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any)]
    public class Work2610Controller : Controller
    {
        public IActionResult Index()
        {
            return View("содержимое модели для демонстрации кеша" as object);
        }
    }
}
