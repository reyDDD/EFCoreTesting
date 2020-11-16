using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class Api1611Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Work()
        { 
            return Ok("otwet");
        }

        [HttpGet("{id}")]
        public IActionResult WorkId(int id)
        {
            return Ok("otwet: " + id);
        }
    }
}
