using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2510
{
    [ApiController]
    [Route("api/[Controller]")]
    public class Api0211Controller : ControllerBase
    {
        public IActionResult ReturnString(string first)
        {
            return Ok(first + " success");
        }
    }
}
