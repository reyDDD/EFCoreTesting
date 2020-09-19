using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Components
{
    public class Cart : ViewComponent
    {
        private ICartRepository repo;
        public Cart(ICartRepository repo)
        {
            this.repo = repo;
        }

        public IViewComponentResult Invoke()
        {
            return View(repo.ReturnCart());
        }
    }
}
