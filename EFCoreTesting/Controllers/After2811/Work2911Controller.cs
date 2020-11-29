using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2811
{
    public class Work2911Controller : Controller
    {
        public IActionResult Index()
        {
            User user = new() { FirstName = "FirstName" };
            var res1 = GetUser(new());
            return View("Index", $"{user.FirstName} {res1.LastName}");
        }

        public User GetUser(User user)
        {
            //....work
            return new() {LastName = "LastName" };
        }
    }
}
