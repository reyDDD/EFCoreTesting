using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Components
{
    public class Comp2510 : ViewComponent
    {

        public IViewComponentResult Invoke(string naVchod)
        {
            return View(naVchod as object);
        }
    }
}
