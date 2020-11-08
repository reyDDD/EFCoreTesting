using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    [Route("api/[controller]")]
    [ApiController]
    public class Api0811Controller : ControllerBase
    {


        /// <summary>
        /// Возвращает текст в формате json
        /// </summary>
        /// <returns></returns>
        [HttpGet("produce")]
        [Produces("application/json")]
        public IActionResult ReturnProduce()
        {
            return Ok("text produce app/json");
        }

        [HttpGet("produce2")]
        [Produces("text/plain")]
        public IActionResult ReturnProduce2()
        {
            return Ok("text produce app/json");
        }

        /// <summary>
        /// Возвращает содержимое в определенном формате в зависимости от запроса
        /// </summary>
        /// <remarks>
        /// описание а блоке remarks
        /// </remarks>
        /// <param name="id">int типа параметр</param>
        /// <returns>Возвращает текст text produce !!!!</returns>
        ///<response code="200">Всегда возвращает 200</response>  
        [FormatFilter]
        [HttpGet("{id}.{format?}")]
        public IActionResult ReturnProduce3(int id)
        {
            return Ok("text produce !!!!");
        }

    }
}
