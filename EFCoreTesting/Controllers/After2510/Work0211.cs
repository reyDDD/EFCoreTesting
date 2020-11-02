using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2510
{
    [ApiController]
    [Route("api/[Controller]")]
    public class Work0211 : ControllerBase
    {
        public IActionResult ReturnString(string first)
        {
            return Ok(first + " success");
        }
    }
}
