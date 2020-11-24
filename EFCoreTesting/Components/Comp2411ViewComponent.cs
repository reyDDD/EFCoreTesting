using EFCoreTesting.Areas.Two.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Components
{
    [ViewComponent(Name = "Fyirk2411")]
    public class Comp2411ViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new Uzver { Age = "dd", User = "dd" });
        }
    }
}
