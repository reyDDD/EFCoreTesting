using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class CartController : Controller
    {
        private ICartRepository repo;
        private One2Many repos;
        public CartController(ICartRepository repo, One2Many repos)
        {
            this.repo = repo;
            this.repos = repos;
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

    }
}
