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
    public class PraisController : ControllerBase
    {
        //[HttpGet("{thisParamater}")]
        //public string GetWithParam(string thisParamater)
        //{
        //    return thisParamater + " прибавка к жалованию";
        //}

        [HttpGet("{id}", Name = "NewRoute")] // что такое наме?
        public string GetWithParam(int id)
        {
            return id + " минус к жалованию";
        }
    }
}
