using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Components
{
    [ViewComponent(Name = "Com2811")]
    public class Comp2811ViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("compPereimenovaniy" as object);
        }
    }
}
