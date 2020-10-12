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

        public IActionResult ReturnUserById(long? id)
        {
            var context = new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=EFCoreTests;Trusted_Connection=True;MultipleActiveResultSets=True;App=EntityFramework;")).Options);

            (int x, string y) = (12, "texts");
            var res = x + y;

            var cort = (12, "vot tak");
            var res2 = cort.Item1 + cort.Item2;

            (int, string) Fu((int x, string y) yes)
            {
                return (x + 10, y + " add");
            }
            var reult = Fu(cort);

            var user = context.Users.Find(id);
            if (id == 0 || user == null)
            {
                return Content("this user not found");
            }
            return View("Index", user);
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
