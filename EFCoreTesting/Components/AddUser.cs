using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Components
{
    public class AddUser : ViewComponent
    {

        public IViewComponentResult Invoke(Address address)
        {
            return View(address);
        }
    }
}
