using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }
            User user = context.Users.FirstOrDefault();
            return View("IndexBind", user);
        }

        [ActionName("Blyat")]
        public IActionResult NewAction(long id)
        {
            return View("IndexBind");
        }

        public IActionResult RedirectToBlyat()
        {
            return RedirectToAction("Blyat");
        }


        [HttpGet]
        public IActionResult GetUser(long id)
        {
            User user = context.Users.Find(id);
            return View("IndexBind", user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(long id, User user)
        {
            if (id != user.Id)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            var userFromBase = context.Users.Where(i => i.Id == id).FirstOrDefault();
            if (userFromBase == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }

            if (await TryUpdateModelAsync<User>(userFromBase,"", i=>i.FirstName, i=>i.LastName))
            {
                context.SaveChanges();
            }
            return RedirectToAction("Blyat", new { id = userFromBase.Id });
        }

    }
}
