using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace EFCoreTesting.Controllers
{
    [ResponseCache(CacheProfileName = "Caching2")]
    [ViewComponent(Name = "PartialComponent")]
    public class CartController : Controller
    {
        private ICartRepository repo;
        private One2Many repos;
        private Notifiyer notifiyer;
        private NotNullModelService notNullServ;
        public CartController(ICartRepository repo, One2Many repos, Notifiyer notifiyer, NotNullModelService notNullServ)
        {
            this.repo = repo;
            this.repos = repos;
            this.notifiyer = notifiyer;
            this.notNullServ = notNullServ;
        }

        //[ResponseCache(Location = ResponseCacheLocation.Any, Duration = 6)]
        public IActionResult Notify()
        {
            (int x, string y) corteg = (3, "text");


            var res3 = notNullServ.ReturnHouseWithoutStreet();


            return View("Notify", Co());
        }

        (int, string) Co()
        {
            return (3, "dsd");
        }

        [HttpPost]
        public IActionResult Notify(int Age, string name)
        {
            notifiyer.PuskNotify(Age, name).GetAwaiter();
            return RedirectToAction(nameof(Notify));
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(Cart cart)
        {
            repo.AddToCart(cart);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Work2309()
        {
            var res = repos.Work2309Get();
            return View(nameof(Index), res);
        }

        [HttpPost]
        public IActionResult Work2309Update(Address address)
        {
            var res = repos.Work2109Update(address);
            return RedirectToAction(nameof(Work2309), nameof(Cart), res);
        }


        public IViewComponentResult Invoke()
        {
            var res = repos.Work2309Get();
            return new ViewViewComponentResult() { ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Address>(ViewData, res) };
        }

    }
}
