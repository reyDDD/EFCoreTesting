using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class Work2809Controller : Controller
    {
        private Work2809 work2809;

        public Work2809Controller(Work2809 work2809)
        {
            this.work2809 = work2809;
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


    }
}
