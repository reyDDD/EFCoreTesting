using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work0111Controller : Controller
    {
        private IMemoryCache cache;
        public Work0111Controller(IMemoryCache cache)
        {
            this.cache = cache;
        }
        public IActionResult Index()
        {
            string vozvrat = string.Empty;

            if (!cache.TryGetValue("myFirst", out vozvrat))
            {
                vozvrat = DateTime.Now.TimeOfDay.ToString();

                var cacheoption = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(5))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(20))
                    .SetPriority(CacheItemPriority.High)
                    .RegisterPostEvictionCallback(callback: EvictionCallBack, state: this);

                cache.Set("myFirst", $"замостил {DateTime.Now.TimeOfDay}", cacheoption);

            }
            string forExample = string.Empty;
            cache.TryGetValue<string>("del", out forExample);
            return View("Index", (vozvrat, forExample));
        }

        public static void EvictionCallBack(object key, object value, EvictionReason reason, object state)
        {
            var message = $"Сущность удалена из кеша. Причина: {reason}";
            ((Work0111Controller)state).cache.Set("del", message);
        }

        public async Task<IActionResult> Index2()
        {
            string vozvrat = await cache.GetOrCreateAsync("mySecond", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(5);
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20);
                return Task.FromResult("tutu" + DateTime.Now.TimeOfDay);
            });
            return View("Index", vozvrat);
        }
    }
}
