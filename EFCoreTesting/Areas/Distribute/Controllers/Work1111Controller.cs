using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class Work1111Controller : Controller
    {
        private Context context;
        public Work1111Controller(Context context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                if (user.Address != null)
                {
                    context.Addresses.Add(user.Address);
                    context.SaveChanges();
                }
                context.Users.Add(user);
                context.SaveChanges();
                transaction.Commit();
            }
            return Ok(context.Users.Find(user.Id).FirstName);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            context = null;
            base.Dispose(disposing);
        }
    }
}
