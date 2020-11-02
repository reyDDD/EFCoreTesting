using EFCoreTesting.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work0211Controller : Controller
    {
        public MemoryCache Cache { get; set; }
        private ILogger<Work0211Controller> logger;
        public Work0211Controller(Cache0211 cache, ILogger<Work0211Controller> logger)
        {
            Cache = cache.Cache;
            this.logger = logger;
        }

        [TempData]
        public string MyTempAttr { get; set; }

        public IActionResult Index()
        {

            if (!Cache.TryGetValue(DateTime.Now.ToString(), out string val))
            {
                val = DateTime.Now.TimeOfDay.ToString();
                var cacheEntry = new MemoryCacheEntryOptions().SetSize(1).SetSlidingExpiration(TimeSpan.FromSeconds(11165));

                Cache.Set(DateTime.Now.ToString(), val, cacheEntry);
            }
            MyTempAttr = val + " " + new Random().Next(1,111111);
            logger.LogInformation("iz meda danniye po cechu: " + Cache.Count.ToString());

            return View("Index");
        }

        protected override void Dispose(bool disposing)
        {
            logger.LogInformation("do udaleniya: " + Cache.Count.ToString());
            Cache.Compact(0.99); //удаляет указанный процент содержимого кеша
            logger.LogInformation("posle udaleniya " + Cache.Count.ToString());
            base.Dispose(disposing);
        }
    }
}
