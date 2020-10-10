using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace EFCoreTesting.Controllers
{
    public class Work1010 : Controller
    {

        public IActionResult Index()
        {
            return View("Index");
        }


        [HttpPost]
        public IActionResult Index(User user)
        {
            var context = new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=EFCoreTests;Trusted_Connection=True;MultipleActiveResultSets=True;App=EntityFramework;")).Options);

            context.Users.Add(user);
            context.SaveChanges();

            return View();
        }
    }
}
