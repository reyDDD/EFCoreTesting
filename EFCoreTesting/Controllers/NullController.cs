using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
   // [Route("[controller]/[action]")]
    public class NullController : Controller
    {
        //[Route("~/")]
       // [Route("/Null")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
