using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace EFCoreTesting.Areas.DistributeCache.Controllers
{
    [Area("Distribute")]
    public class Work0211Controller : Controller
    {
        private readonly IDistributedCache cache;
        public Work0211Controller(IDistributedCache cache) //DI подставляю нужный вариант распределенного кеширования и вуаля - все работает
        {
            this.cache = cache;
        }

        public async Task< IActionResult> Index()
        {
            var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(300));

            await cache.SetAsync("key1", Encoding.UTF8.GetBytes("znach1"), options);
   
            var intermediateResult = await cache.GetAsync("key1");
            var res = Encoding.UTF8.GetString(intermediateResult);
            return View("Index", res);
        }
    }
}
