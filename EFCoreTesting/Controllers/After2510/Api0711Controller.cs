using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Api0711Controller : ControllerBase
    {

        [HttpGet]
        public IActionResult Getid(int id)
        {
            return Ok("[HttpGet] " + id);
        }

        //при выборе одного из двух маршрутов ниже выбирает тот, что {id:int}
        [HttpGet("tut/{id}")]
        public IActionResult GetId(int id)
        {
            return Ok("[HttpGet('tut/{id}')] " + id);
        }

        [HttpGet("tut/{id:int}")]
        public IActionResult GetId2(int id)
        {
            return Ok("[HttpGet('tut222/{id}')] " + id);
        }
    }
}
