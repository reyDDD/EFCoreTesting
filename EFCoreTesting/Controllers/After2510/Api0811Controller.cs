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

        [FormatFilter]
        [HttpGet("{id}.{format?}")]
        public IActionResult ReturnProduce3(int id)
        {
            return Ok("text produce !!!!");
        }

    }
}
