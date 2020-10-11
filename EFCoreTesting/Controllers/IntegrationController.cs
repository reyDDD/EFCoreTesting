using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class IntegrationController : Controller
    {
        private readonly Iintegra iintegra;

        public IntegrationController(Iintegra iintegra)
        {
            this.iintegra = iintegra;
        }

        public ActionResult<List<string>> Index()
        {
            return View(iintegra.ReturnList());
        }
    }
}
