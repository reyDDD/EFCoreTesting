using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Components
{
    public class NameComp : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View( "ff" as object);
        }
    }
}
