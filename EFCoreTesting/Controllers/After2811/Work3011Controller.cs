using EFCoreTesting.Models.After3011;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2811
{
    public class Work3011Controller : Controller
    {
        public IActionResult Index()
        {
            Model3011 model = new Model3011();
            try
            {
                IEnumerable<string> res = model.GetList();
                return View(res);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
    }
}
