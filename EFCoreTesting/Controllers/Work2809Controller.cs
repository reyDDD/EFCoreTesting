﻿using System;
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
        private ServiceWithAnalogDBContext analogContext;

        public Work2809Controller(Work2809 work2809, Vozvrat2909 vozvrat2909, ServiceWithAnalogDBContext analogContext)
        {
            this.work2809 = work2809;
            this.vozvrat2909 = vozvrat2909;
            this.analogContext = analogContext;
        }

        public IActionResult AddUser(string name = "Alex", string lastName = "Popkorn", int Age = 22)
        {
            work2809.AddUser(name, lastName, Age);
            return View();
        }


        public IActionResult Index()
        {
            var res = analogContext.GetAddressWithFilterUser(3);
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


        public IActionResult Index4()
        {
            var res = vozvrat2909.Work2909();
            return View("Index4", res);
        }

        [HttpPost]
        public IActionResult Index4(Address address, Address original = null)
        {
            var res = vozvrat2909.UpdateAddressU(address, original);
            return View("Index4", res);
        }


    }
}
