using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work2810Controller : Controller
    {
        private IList<Model2810> list;
        public Work2810Controller()
        {
            list = new List<Model2810>();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult Index(Model2810 model)
        {

            if (!ModelState.IsValid)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            list.Add(model);
            return View("Index" , list);
        }

        public IActionResult Index2()
        {
            return View("Index");
        }

    }
}
