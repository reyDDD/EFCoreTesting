using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpGet, ActionName("Suda")]
        public IActionResult Index(string? name)
        {
            var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>());
            User user = default;
            if (context.Users.Any())
            {
                context.Users.FirstOrDefault();
            }

            
            return View(user);
        }

        [ValidateAntiForgeryToken]
        public IActionResult Index2([Bind(include: "Id")]User userec)
        {
            if (userec.Id == 0)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }
            var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>());
            User user = default;
            if (context.Users.Any())
            {
                context.Users.Find(userec.Id);
            }


            return View("Index", user);
        }


        public IActionResult Redir(string name, string pustishka)
        {
            return CreatedAtAction("Suda", new { name = name} , name); //используется для создания заголовка ответа, фактический вызов метода не происходит. Метод указывает, что в случае вызова данного запроса по пути с такими параметрами будет получен итоговый результатв  третьем параметре
        }
    }
}
