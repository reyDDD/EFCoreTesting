using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    [Api0911]
    [ApiController]
    public class Api0911bController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Index(string pipi)
        {

            return pipi + " pipi";
        }
    }
}
