using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreTesting.Controllers
{
    public class Work1510Controller : Controller
    {
        private IServiceProvider provider;

        public Work1510Controller(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public async Task<IActionResult> Index(string searchCity, string country)
        {
            var context = new Context(provider.GetRequiredService<DbContextOptions<Context>>());

            var listAddress = context.Addresses.AsQueryable();
            if (!String.IsNullOrEmpty(searchCity))
            {
                listAddress = listAddress.Where(m=>m.City.Contains(searchCity));
            }
            if (!String.IsNullOrEmpty(country))
            {
                listAddress = listAddress.Where(m => m.Country == country);
            }

            var listCountry = new SelectList(await context.Addresses.Select(m=>m.Country).Distinct().ToListAsync());

            return View((await listAddress.ToListAsync(), listCountry));
        }
    }
}
