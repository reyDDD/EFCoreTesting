using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Components
{
    //[ViewComponent(Name = "NewCoponent")]
    public class Component2611ViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(string Name)
        {
            return View("Default", $"{Name} добавка");
        }
    }
}
