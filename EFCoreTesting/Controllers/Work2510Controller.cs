using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class Work2510Controller : Controller
    {
        private IWork2510Model repo;

        public Work2510Controller(IWork2510Model repo)
        {
            this.repo = repo;
        }

  
        public async Task<IActionResult> Index(long id)
        {
            User user = await repo.GetUser(id);
            return View("Index", user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserWithAddress(User user)
        {
            await repo.UpdateUserAndAddress(user);
            return RedirectToAction("Index", new { id = user.Id });
        }
    }
}
