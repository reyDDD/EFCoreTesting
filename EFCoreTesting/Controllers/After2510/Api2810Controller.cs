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
    public class Api2810Controller : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> ReturnString()
        {
            return "znachatina";
        }

        [HttpGet("{znach:int}")]
        public async Task<ActionResult<string>> ReturnStringWithParam(int znach)
        {
            await Task.FromResult(znach);
            return znach + ":int";
        }

        [HttpGet("tut")] //если указать [HttpGet("/tut")], маршрут api/[controller]/tut не отработает, но отработает /tut
        public async Task<ActionResult<string>> ReturnStringWithParamAndNotQuery(string znach)
        {
            await Task.FromResult(znach);
            return "tut " + znach;
        }
    }
}
