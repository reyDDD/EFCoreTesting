using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EFCoreTesting.Controllers.After2510
{
    [ViewComponent(Name = ("Combinator"))]
    public class Work2510UniqueContextController : Controller
    {
        private IWork2510ModelRepo2 modelRepo2;
        public Work2510UniqueContextController(IWork2510ModelRepo2 modelRepo2)
        {
            this.modelRepo2 = modelRepo2;
        }

        protected override void Dispose(bool disposing)
        {
            this.modelRepo2.Dispose();
            base.Dispose(disposing);    
        }
        public async Task<IActionResult> Index(int id)
        {
            var res = await modelRepo2.GetUser(id);
            if (res == null)
            {
                return NotFound();
            }
            return View(res);
        }
        public async Task<IActionResult> Index2(User user)
        {
            if (!ModelState.IsValid || user.Id == 0)
            {
                return BadRequest(ModelState);
            }

            var res = await modelRepo2.GetUser(user.Id);
            if (res == null)
            {
                return NotFound();
            }
            return View("Index", res);
        }


        public async Task<IActionResult> GetUserAtData(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = await modelRepo2.GetUserAtData(user);
            if (res == null)
            {
                return NotFound();
            }
            return View("Index", res);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(long idUser, User user)
        {
            var usssr = await modelRepo2.GetUser(idUser);

            if (await TryUpdateModelAsync(usssr, "", m => m.FirstName, m => m.LastName))
            {
                await modelRepo2.UpdateUser(usssr);
            }

            return View("Index", usssr);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<User>(ViewData, await modelRepo2.GetUser(22))
            };
        }

   
    }
}
