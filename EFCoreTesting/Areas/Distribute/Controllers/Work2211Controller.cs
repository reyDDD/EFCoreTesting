using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class Work2211Controller : Controller
    {
        [ActionName("Secret")]
        public async Task< IActionResult> Index(int id, User user, [FromServices] Context context)
        {
            if (id is 0 )
            {
                return new StatusCodeResult((int)HttpStatusCode.Found);
            }
            else if(id is > 4)
            {
                User userr = context.Users.Single(x => x.Id == id);
                if (await TryUpdateModelAsync<User>(userr, "", x => x.IsMale, x=>x.FirstName))
                {
                    return new StatusCodeResult((int)HttpStatusCode.OK);
                }
            }
            return View("Index");
        }


        public IActionResult Redir()
        {
            return RedirectToAction("Secret", new { id = 1});
        }

        public IActionResult Search(string name, string lastName, [FromServices] Context context)
        {
            var f = context.Users.Where(i => i.FirstName.Contains(name));
            var s = f?.Where(c => c.LastName.Contains(lastName)).ToList();
            string? model = $"{s?.FirstOrDefault()?.FirstName} {s?.FirstOrDefault()?.LastName}";
            return View("Index", model);
        }

    }
}
