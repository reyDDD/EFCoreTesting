using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class OneManyController : Controller
    {
        private One2Many one2Many;

        public OneManyController(One2Many one2Many)
        {
            this.one2Many = one2Many;
        }
        public IActionResult Index()
        {
            ViewBag.WorkingAddress = TempData["WorkAddress"];
            var res = one2Many.GetUsersWithAddresses();
            return View(res);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Address>> UpdateUsers(IEnumerable<Address> address)
        {
            var res = one2Many.UpdateAddressWithUsers(address);
            return RedirectToAction("Index", res);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Address>> AddUserThroughAddress(Address address)
        {
            var res = one2Many.UpdateAddressWithUsers(address);
            return RedirectToAction("Index", res);
        }

        public IActionResult UpdateUsers(int id)
        {
            TempData["WorkAddress"] = id;
            return RedirectToAction(nameof(Index));
        }
    }
}
