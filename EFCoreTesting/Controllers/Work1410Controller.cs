using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
 
namespace EFCoreTesting.Controllers
{
    public class Work1410Controller : Controller
    {
        private Context context;
 
        public Work1410Controller(Context context)
        {
 
            this.context = context;
        }

        public IActionResult Index()
        {
            
            return new StatusCodeResult((int)HttpStatusCode.NotFound);
        }

        [HttpPost]
        [ActionName("UpdateAddress")]
        public async Task<IActionResult> Index(int id)
        {
            Address adres = context.Addresses.Find(id);
            if (await TryUpdateModelAsync<Address>(adres, "", m => m.City))
            {
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Model has error(s)");
                }
            }
 
       
            return RedirectToAction("GetAddress", new { id = adres.Id });
        }


        [HttpGet]
        [ActionName("GetAddress")]
        public async Task<IActionResult> IndexGet(int id)
        {
            Address adres = await context.Addresses.FindAsync(id);
            if (adres != null)
            {
                return View("Address2", adres);
            }

            return View("Address2");
        }

    }
}
