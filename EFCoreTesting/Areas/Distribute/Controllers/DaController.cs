using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class DaController : Controller
    {

        private IConfiguration config;

        public DaController()
        {
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); //IConfigurationRoot реализует интерфейс iConfiguration
        }
        public IActionResult Index()
        {
            string stroca = config.GetConnectionString("DefaultConnection");
            return View("Index", new TwoData { Data1 = DateTime.Now, Data2 = DateTime.Now });
        }


        public IActionResult IndexBind([Bind("FirstName,LastName")]User user)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
            return View("IndexBind");
        }
    }
}
