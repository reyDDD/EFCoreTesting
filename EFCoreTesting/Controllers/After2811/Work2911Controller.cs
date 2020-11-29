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
        public IActionResult Work1()
        {
            User user = new User();
            bool tr = user is User; //шаблон проверки соответсвия типу
            bool tr2 = (tr is true and (4 > 3)) || (tr is not false); //шаблон в круглых скобках подчеркивает приоритет 
            bool tr3 = (user.Id is (not 5) or (6 and > 2));
            string tpe = tr2 == true ? "user is User" : "user is not User";
            return View("Index", $"{tpe}");
        }

        public IActionResult Work2()
        {
            Model2911 model = new Model2911() { InitProperty = "стартонул" };
            Model2911 model2 = new Model2911();
            return View("Index", model2.InitProperty);
        }

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
