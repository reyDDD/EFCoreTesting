using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class WorkRelationController : Controller
    {
        private WorkRelation workRelation;
        public WorkRelationController(WorkRelation workRelation)
        {
            this.workRelation = workRelation;
        }
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult AddUser(User? user)
        {
            if (user != null)
            {
                workRelation.AddUser(user);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateAddressThroughUser(long id)
        {
            User us = workRelation.GetUser(id);
            return View(nameof(UpdateAddressThroughUser), us);
        }

        [HttpPost]
        public IActionResult UpdateAddressThroughUser(User changeUser, User originUser = null)
        {
            workRelation.UpdateAddressThroughUser(changeUser, originUser);
            return RedirectToAction(nameof(Index));
        }

    }
}
