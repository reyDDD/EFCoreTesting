using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTesting.Controllers
{
    public class DALController : Controller
    {
        private IVozvrat2909 vozvrat2909;

        public string Country { get; set; }
        public DALController(IVozvrat2909 vozvrat2909)
        {
            this.vozvrat2909 = vozvrat2909;
        }
        public IActionResult Index()
        {
            var res = vozvrat2909.Work2909();
            return View(res);
        }

        public IActionResult SetCountry()
        {
            var res = vozvrat2909.Work2909();
            Country = res.Country;
            return View(res);
        }


    }
}
