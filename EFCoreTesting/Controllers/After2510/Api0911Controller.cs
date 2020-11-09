using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2510
{
    [Route("api/[controller]")]
    [ApiController]
    public class Api0911Controller : ControllerBase
    {
        [HttpGet("{name}")]
        public ActionResult<string> Index(string name)
        {
            return name;
        }
    }
}
