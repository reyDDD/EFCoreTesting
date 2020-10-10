using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{

   
    public class NotNullController : Controller
    {
        private INotNullModelService serciceNotNull;

        public NotNullController(INotNullModelService serciceNotNull)
        {
            this.serciceNotNull = serciceNotNull;
        }

        [ResponseCache(Duration = 12)]
        public IActionResult Index24()
        {
            return View("Index");
        }


        [ResponseCache(Duration = 12)] //работает при условии, что на странице не содержится форма
        public IActionResult Index22(NotNullModel? streetas)
        {
            return View("Index22");
        }




            public IActionResult Index2(NotNullModel? streetas)
        {
             if (streetas == null)
            {
                return new BadRequestResult();
            }
            else if(streetas!.Id != 0 || streetas.Street != null)
            {
                if (TempData != null)
                {
                    ViewBag.Re = "ll";
                }
                else
                {
                    ViewBag.Re = "33";
                }

                var model = serciceNotNull.ReturnNotNullModelWithHose(streetas);
                if (model == null)
                {
                    return NotFound(streetas.Id);
                }
                return View("Index", model);
            }
                return View("Index");
        }


        [HttpPost]
        public IActionResult Index(NotNullModel streetas, bool isTrue = false)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("dd", "какой дебил придумал эти нуллы?");
                return BadRequest(ModelState);
            }

            if (streetas!.House!.First()!.Home == null)
            {
                TempData["Re"] = "yes";
                return RedirectToAction(nameof(Index2), streetas);
            }

                var res = serciceNotNull.AddHouseToStreet(streetas, isTrue);
                return RedirectToAction(nameof(Index2), res);

        }

    }
}
