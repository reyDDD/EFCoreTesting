using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work2710Controller : Controller
    {
        private IServiceProvider serviceProvider;

        public Work2710Controller(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public IActionResult Index()
        {
            var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>());
            var user = context.Users.FirstOrDefault();
            return View(user);
        }
    }
}
