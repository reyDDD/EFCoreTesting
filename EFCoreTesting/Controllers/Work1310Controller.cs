﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class Work1310Controller : Controller
    {
        private IServiceProvider serviceProvider;

        public Work1310Controller(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public IActionResult Index()
        {
            GetContextFromIServiceProvider provider = new GetContextFromIServiceProvider();
            var context = provider.ReturnContext(serviceProvider);

            Address res = default;

            if (context.Addresses.Any())
            {
                res = provider.ReturnDataFromBase(context).Result;
            }
            else
            {
                return BadRequest("The base contains null elements Address");
            }

            return View("Address", res);
        }
    }
}
