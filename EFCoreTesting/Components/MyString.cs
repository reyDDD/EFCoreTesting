using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Components
{
    public class MyString : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View("Строка в ответе" as object);
        }
    }
}
