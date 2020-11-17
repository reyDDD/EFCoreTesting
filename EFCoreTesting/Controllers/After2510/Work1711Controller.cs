using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work1711Controller : Controller
    {
        private Context context;

        public Work1711Controller(Context context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            Moda model = context.Addresses.Where(i => i.City != null).Select(m => new Moda { City = m.City, Country = m.Country }).FirstOrDefault();

            return Ok($"{model.City} {model.Country}");
        }

        public class Moda
        {
            public string City { get; set; }
            public string Country { get; set; }
        }
    }
}
