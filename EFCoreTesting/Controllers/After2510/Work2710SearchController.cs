using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work2710SearchController : Controller
    {
        private Context context;
        public Work2710SearchController(Context context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(string searchUser, string country)
        {
            ViewBag.Country = new SelectList( await context.Addresses.Select(n=>n.Country).Distinct().ToListAsync());

            var listUser = context.Users.Include(s=>s.Address).AsQueryable();
            if (searchUser != null)
            {
                listUser = listUser.Where(u => u.LastName.Contains(searchUser));
            }
            if (country != null)
            {
                listUser = listUser.Where(c => c.Address.Country == country);
            }
            
            return View("Index", await listUser.ToListAsync());
        }
    }
}
