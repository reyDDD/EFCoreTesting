using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Infrastructure.Mediatr;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class Work1211MediatorController : Controller
    {
        private IMediator<IEventForMediator> mmediator;
        public Work1211MediatorController(IMediator<IEventForMediator> mmediator)
        {
            this.mmediator = mmediator;
        }
        public IActionResult Index(string name, string family, string city, string country)
        {
            IEventForMediator mediatora = new EventForMediatorConcrete(mmediator)
            {
                Name = name,
                Family = family,
                Country = country,
                Address = city
            };
            var result = mediatora.Send();
            return View("Index", result);
        }
    }
}
