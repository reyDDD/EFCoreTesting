using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    //[Route("[controller]/[action]")]
    public class Work0911Controller : Controller
    {
        [HttpGet("dfd/{id}", Name = "One")] // при таком объявлении метод доступен по адресу https://localhost:44356/vperet,%20matros , что не есть ожидаемо. Проблему решает [Route("[controller]/[action]")] примененный к классу

        public IActionResult Index0(string id)
        {
            return View("Index", (id + " id1") as object);
        }

        [HttpGet("id2/{id2}", Name = "One2")]
        public IActionResult Index2(string id2)
        {
            var id2s = " " + Url.Action("Index0", "Work0911", new { id = id2 }); //имя действия и контроллера прописывать жестко, иначе контроллер принимает вида MyController и ссылка битая
            return View("Index", (id2s + " id2") as object);
        }

        [HttpGet("id3/{id3}", Name = "One3")]
        public IActionResult Index3(string id3)
        {
            var ss = Url.RouteUrl("One", new { id = id3 });
            return View("Index", (ss + " id3") as object);
        }

        [HttpGet("[controller]/[action]/id4/{id4}", Name = "One4")]
        public IActionResult Index4(string id4)
        {
            var ss = Url.Action("Index0", new { id = id4 });
            return View("Index", (ss + " id4") as object);
        }
    }
}
