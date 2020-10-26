using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EFCoreTesting.Models;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index2(string text)
        {
            return View("Index", HtmlEncoder.Default.Encode(text) as object);
        }


        public IActionResult DataT()
        {
            Model2610 model = new Model2610()
            {
                Date = DateTime.Now,
                Url = "https://site.com",
                Mail = "info@mail.ru"
            };
            return View("DataT", model);
        }

        [HttpPost]
        public IActionResult DataTy(Model2610 model)
        {
 
            return View("DataT", model);
        }
    }
}
