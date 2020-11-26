using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Components.Component2611
{
    [ViewComponent(Name = "Probn")]
    public class ProbniyViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string Name)
        {
            return View("Default", $"{Name} добавка");
        }
    }
}
