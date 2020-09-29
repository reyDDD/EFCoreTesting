using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class Work2809Controller : Controller
    {
        private Work2809 work2809;
        private Vozvrat2909 vozvrat2909;

        public Work2809Controller(Work2809 work2809, Vozvrat2909 vozvrat2909)
        {
            this.work2809 = work2809;
            this.vozvrat2909 = vozvrat2909;
        }

        public IActionResult Index()
        {
            var res = work2809.GetAddressWithFilterUser(3);
            return View(res);
        }

        public IActionResult Index2()
        {
            var res = work2809.GetAddressWithUser2();
            return View(res);
        }

        public IActionResult Index3()
        {
            var res = vozvrat2909.Work2909();
            return View("Index3", res);
        }

        [HttpPost]
        public IActionResult Index3(Address address)
        {
            var res = vozvrat2909.UpdateAddress(address);
            return View("Index3", res);
        }

    }
}
