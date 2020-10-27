using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    [Route("api/[controller]")]
    [ApiController]
    public class Api2710Controller : ControllerBase
    {
        private IWork2510ModelRepo2 work2510ModelRepo2;

        public Api2710Controller(IWork2510ModelRepo2 work2510ModelRepo2)
        {
            this.work2510ModelRepo2 = work2510ModelRepo2;
        }

        [HttpGet]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser([FromQuery]long id)
        {
            var user = await work2510ModelRepo2.GetUser(id);
            return user;
        }
    }
}
