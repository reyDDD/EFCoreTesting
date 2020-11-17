﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Infrastructure.Mediator1711;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work1711Controller : Controller
    {
        private Context context;
        private IObbrabotchik<StartClass, EndClass> obbrabotchik;
        IMedi<StartClass> medi;


        public Work1711Controller(Context context, IObbrabotchik<StartClass, EndClass> obbrabotchik, IMedi<StartClass> medi)
        {
            this.context = context;
            this.obbrabotchik = obbrabotchik;
            this.medi = medi;
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

        public IActionResult Mediator([FromQuery] StartClass startClass)
        {
            EndClass res = obbrabotchik.Pusk(startClass);
            return Ok($"{res.Age} {res.Name}");
        }

        public IActionResult NotMediator([FromQuery] StartClass param)
        {
            EndClass result = new EndClass { Age = param.Age, Name = param.Name };  
            var megdu = result.Name;

            return Ok($"{result.Age} {result.Name}");
        }
    }
}
