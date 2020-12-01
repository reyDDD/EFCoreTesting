using EFCoreTesting.Areas.Two.Controllers;
using EFCoreTesting.Models;
using EFCoreTesting.Models.Chain0112;
using EFCoreTesting.Models.WithParamForDI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2811
{
    public class Work0112Controller : Controller
    {
        public IActionResult Index(string data)
        {
            Original original = new Original();
            string res = original.Zamostit(data);
            return View("Index", res);
        }

        public IActionResult Index2()
        {
            Original original = new Original();
            string res = original.Zamostit2("data");
            return View("Index", res);
        }

        public IActionResult Index3()
        {
 
            return View("Index", "data");
        }

        public IActionResult Index4([FromServices] IConfiguration configuration)
        {
            string res = configuration.GetValue<string>("vanek");
            return View("Index", res);
        }

        public IActionResult Index5([FromServices] IOru oru)
        {
            string res = oru.MyProperty + oru.MyProperty2;
            return View("Index", res);
        }

        public IActionResult Index6([FromServices] Context context)
        {
            Uzver res = context.Users.Where(x => x.Id == 22).Select(x => new Uzver { Age = x.FirstName, User = x.LastName }).FirstOrDefault();
            
            return View("Index", res.Age + " " + res.User);
        }

        public IActionResult Index7([FromServices] Context context)
        {
            var user = context.Users.Where(x => x.Id == 22).FirstOrDefault();
            user.LastName = "Далеко не прстачок";
            var res = context.Users.Where(x => x.Id == 22).FirstOrDefault();
            return View("Index", res.FirstName + " " + res.LastName);
        }

    }
}
