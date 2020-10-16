using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiWork1610Controller : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "privet Index";
        }

        [HttpGet("{priyem}")]
        public string Index(string priyem)
        {
            return $@"privet {priyem} Index";
        }

        [HttpGet("int/{priyem:int}")]
        public string Index(int priyem)
        {
            return $@"privet {priyem} Index";
        }
    }
}
