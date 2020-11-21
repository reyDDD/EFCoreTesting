using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class Work2110Controller : Controller
    {

        public IActionResult Index(int id)
        {
            return (id) switch
            {
                (0) => Ok("параметр указан не был"),
                (1) => Ok("параметр равен 1"),
                int ids when ids is 3 and < 5 => Ok("параметр равен больше трех"),
                int fignya when fignya is 6 or <= 7 => Ok("параметр равен 6 или меньше чем 7"),
                var fignya when fignya is not 8 => Ok("параметр не равен 8"),
                (_) => Ok("и ничего не присвоено - ни один вариант проверки не прошел")
            };
        }


        public IActionResult Index2(int id)
        {
            string? result = null;
            if (id is 0)
            {
                result = "параметр указан не был";
            }
            result ??= "и ничего не присвоено - ни один вариант проверки не прошел";
            return Ok(result);
        }
    }
}
