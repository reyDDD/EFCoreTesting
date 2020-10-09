using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EFCoreTesting.Controllers
{
    [ViewComponent(Name = "Combo0810")]
    public class Work0810Controller : Controller
    {

        private Work2809 work2809;

        public Work0810Controller(Work2809 work2809)
        {
            this.work2809 = work2809;
        }
        public Work0810Controller()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            var res = work2809.GetAddressWithUser();
            return View("Index", res);
        }


        public IViewComponentResult Invoke()
        {
            return new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<string>(ViewData, "текст для модели")
            };
        }

    }
}
