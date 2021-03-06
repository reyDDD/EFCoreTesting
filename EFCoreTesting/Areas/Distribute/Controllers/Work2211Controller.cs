﻿using EFCoreTesting.Models;
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


        public IActionResult Convart(string numba)
        {
            if (numba is null or "")
            {
                return View("ForStart");
            }
            if (ModelState.IsValid)
            { 
                Model2211 model2211 = new Model2211 { ForChange = numba };
                var c = model2211.Origin.GetType() ;
  
            }

            return View("Index");
        }


        public IActionResult TwoSearch([FromServices]Context context)
        {
            context.Users.Where(x => x.Id == 22).FirstOrDefault();
            context.Users.FirstOrDefault(x => x.Id == 22);
            context.Users.Single(x => x.Id == 22);
            context.Users.Where(x => x.FirstName.Contains("ff"));
            return RedirectToAction("Secret", new { id = 1 });
        }


    }
}
