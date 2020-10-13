using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var res = provider.ReturnDataFromBase(context);
            return View("Address", res.Result);
        }
    }
}
