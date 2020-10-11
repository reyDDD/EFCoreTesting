using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTesting.Controllers
{
    public class DALController : Controller
    {
        private Context context { get; }
        private Vozvrat2909 vozvrat2909;

        public DALController(DbContextOptions<Context> options)
        {
            this.context = new Context(options);
            vozvrat2909 = new Vozvrat2909(context);
        }
        public IActionResult Index()
        {
            var res = vozvrat2909.Work2909();
            return View(res);
        }
    }
}
