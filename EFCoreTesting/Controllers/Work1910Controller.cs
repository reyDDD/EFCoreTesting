using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class Work1910Controller : Controller
    {

        private Vozvrat2909 vozvrat2909;
        public Work1910Controller(Vozvrat2909 vozvrat2909)
        {
            this.vozvrat2909 = vozvrat2909;
        }

        public async Task< IActionResult> GetAddress()
        {
            IQueryable<Address> res = await vozvrat2909.GetAddress();
            return View("TestVozvrat", res);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2(int id)
        {
            Address address = vozvrat2909.GetAddressId(id);
            return View("Index", address);
        }

        public IActionResult Index3(int id)
        {
            Address address = vozvrat2909.GetAddressId(id);
            return View("AddUserView", address);
        }

        [HttpPost]
        public IActionResult UpdateWithNavigation(Address address)
        {
            vozvrat2909.UpdateAddress2(address);
            return View();
        }
    }
}
