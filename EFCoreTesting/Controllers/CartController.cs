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
        public CartController(ICartRepository repo)
        {
            this.repo = repo;
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
    }
}
