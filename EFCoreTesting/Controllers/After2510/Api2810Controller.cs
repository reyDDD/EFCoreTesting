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
    public class Api2810Controller : ControllerBase
    {
        private IWork2510ModelRepo2 repo;

        public Api2810Controller(IWork2510ModelRepo2 repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<string>> ReturnString()
        {
            return "znachatina";
        }

        [HttpGet("{znach:int}", Name = "ReturnErrorData")]
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


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> AddUserAsync(User user)
        {
            await repo.AddUserAsync(user);
            return CreatedAtAction("ReturnErrorData", user.Id, user);
        }
    }
}
