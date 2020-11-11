using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

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

        [ResponseCache(Duration = 30)]
        public IActionResult Index()
        {
            var user = context.Users.FirstOrDefault(x => x.IsMale == true);
            var user2 = context.Users.Where(x => x.IsMale == true).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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


        public IActionResult WorkWithCashe([FromServices] IDistributedCache cache)
        {
            string dataFromCache = default;
            var res = cache.Get("key1111");
            if (res != null)
            {
                dataFromCache = Encoding.UTF8.GetString(res);
            }
            else
            {
                var option = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(10));
                cache.Set("key1111", Encoding.UTF8.GetBytes(DateTime.Now.TimeOfDay.ToString()), option);
                dataFromCache = Encoding.UTF8.GetString(cache.Get("key1111"));
            }
            return Ok(dataFromCache);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            context = null;
            base.Dispose(disposing);
        }
    }
}
