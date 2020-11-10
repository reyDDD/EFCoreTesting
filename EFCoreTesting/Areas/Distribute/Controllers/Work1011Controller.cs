using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class Work1011Controller : Controller
    {
        private Model1011 model1011;
        public Work1011Controller(Model1011 model1011)
        {
            this.model1011 = model1011;
        }

        public IActionResult Index()
        {
            Address address = new Address { City = "достойный город", Country = "достойная страна" };
            User user = new User { FirstName = "достойное имя", LastName = "достойная фамилия", Age = 33, BirthDay = DateTime.Now, IsMale = true, Address = address };
            model1011.AddAddressWithUser(user);
            return View();
        }

        public IActionResult IndexWithNewContext([FromServices] Context1011 context1011)
        {
            string city = context1011.Addresses.FirstOrDefault().City;
            return View("Index", city);
        }
    }
}
