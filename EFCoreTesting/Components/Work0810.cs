using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Components
{
    public class Work0810 : ViewComponent
    {

        public IViewComponentResult Invoke(string name)
        {
             return View("Work0810", name + " прибавка к жалованию");
        }
    }
}
