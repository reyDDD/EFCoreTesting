using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    [Route("api/[controller]")]
    [ApiController]
    public class Api2910Controller : ControllerBase
    {

        [HttpGet]
        public IActionResult ReturnOkJson()
        {
            return Ok(new User { Id = 5, FirstName = "Petrov", LastName = "Ivan" });
        }

        [FormatFilter]
        //[Produces("application/json")] //и после этого указания, применимого к контроллеру или экшину, тип возвращаемого значения - исключительно заявленный
        [HttpGet("text/{id}.{format?}")]
        public IActionResult ReturnOkText(int id)
        {
            return Ok("просто текст"); //если текст, то возвражает в формате текста, а сложные типы сериализует в json (и при условии, что в стартапе не прописано удаление соответствующего форматировщика
        }

        [HttpGet("content")]
        public ContentResult ReturnContent()
        {
            return Content("контентище");
        }

        [HttpGet("js")]
        public IActionResult ReturnJs()
        {
            return new JsonResult(new User { Id = 5, FirstName = "Petrov", LastName = "Ivan" }, new JsonSerializerOptions
            {
                WriteIndented = true // вытягивает результты в одну строку, если смотреть в браузере
            });
        }

        [HttpGet("jsc")]
        public IActionResult ReturnJsС()
        {
            return new JsonResult(new User { Id = 5, FirstName = "Petrov", LastName = "Ivan" });
        }

        [HttpGet("from")]
        public IActionResult ReturnfrBody( int text)
        {
            return Ok(text + " from body");
        }
    }
}
