using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class Work2211Controller : Controller
    {
        [ActionName("Secret")]
        public async Task< IActionResult> Index(int id, User user, [FromServices] Context context)
        {
            if (id is 0 )
            {
                return new StatusCodeResult((int)HttpStatusCode.Found);
            }
            else if(id is > 0)
            {
                User userr = context.Users.Single(x => x.Id == id);
                if (await TryUpdateModelAsync<User>(userr, "", x => x.IsMale, x=>x.FirstName))
                {
                    return new StatusCodeResult((int)HttpStatusCode.OK);
                }
            }
            return View();
        }
    }
}
