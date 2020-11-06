using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class DaController : Controller
    {
        private Context context;
        private IConfiguration config;

        public DaController(IServiceProvider provider)
        {
            context = new Context(provider.GetRequiredService<DbContextOptions<Context>>());
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); //IConfigurationRoot реализует интерфейс iConfiguration
        }
        public IActionResult Index()
        {
            string stroca = config.GetConnectionString("DefaultConnection");
            return View("Index", new TwoData { Data1 = DateTime.Now, Data2 = DateTime.Now });
        }

        [ValidateAntiForgeryToken]
        public IActionResult IndexBind([Bind("FirstName,LastName")]User user)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
            return View("IndexBind");
        }

        public IActionResult ReturnUser()
        {
            if (!context.Users.Any())
            {
                return NotFound();
            }
            User user = context.Users.FirstOrDefault();
            return View("IndexBind", user);
        }
    }
}
