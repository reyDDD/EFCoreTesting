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


       
        public IActionResult GetListAdresses()
        {
            var res = workOne2Many.GetListAdresses();
            return View("ListAddresses", res);
        }

        public IActionResult GetListAdressesWithFilter()
        {
            var res = workOne2Many.GetListAdressesWithFilter();
            return View("ListAddresses", res);
        }

        public IActionResult PartialError()
        {
            var res = workOne2Many.GetListWithError();
            return View("ListUser", res);
        }

    }
}
