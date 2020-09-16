using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class One2ManyController : Controller
    {
        private WorkOne2Many workOne2Many;
        public One2ManyController(WorkOne2Many workOne2Many)
        {
            this.workOne2Many = workOne2Many;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrUpdateOneToMany(User user)
        {
            workOne2Many.AddOrUpdate(user);
            return View("Index");
        }



   


    }
}
