using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EFCoreTesting.Infrastructure;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class Work1011Controller : Controller
    {
        private IModel1011 model1011;

        public Work1011Controller(IModel1011 model1011)
        {
            this.model1011 = model1011;
        }

        public IActionResult Index()
        {
            Address address = new Address { City = "достойный город", Country = "достойная страна" };
            User user = new User { FirstName = "достойное имя", LastName = "достойная фамилия", Age = 33, BirthDay = DateTime.Now, IsMale = true, Address = address };
            model1011.AddAddressWithUser(user);
            return View();
        }


        public IActionResult IndexWithNewContext([FromServices] Context1011 context1011)
        {
            string city = context1011.Addresses.FirstOrDefault().City;
            return View("Index", city);
        }


        [ResponseCache(Duration = 40)]
        //[ResponseCache(VaryByQueryKeys = new string[] { "param", "dd", "bb" }, Duration = 30)] //если один из ключей явяляется параметром метода и его значение меняется, тогда программа должна возвращать новый результат, иначе - кешированный. По факту не работает!!!
        public IActionResult TestVaryByQueryKeys(string param)
        {
            string data = DateTime.Now.TimeOfDay.ToString();
            return View("Index", data);
        }

        public IActionResult TestIMemoryCache([FromServices] IMemoryCache memoryCache)
        {
            DateTime dates;
            if (!memoryCache.TryGetValue("key", out dates))
            {
                dates = DateTime.Now;
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(10));
                memoryCache.Set("key", dates, cacheEntryOptions);
            }
            return View("Index", dates.TimeOfDay.ToString());
        }

        public IActionResult TestGetOrCreateIMemoryCache([FromServices] IMemoryCache memoryCache)
        {
            DateTime dates = memoryCache.GetOrCreate<DateTime>("key", entry =>
            {
                entry.SetSlidingExpiration(TimeSpan.FromSeconds(10));
                entry.SetAbsoluteExpiration(TimeSpan.FromSeconds(15));
                entry.SetPriority(CacheItemPriority.Normal);
                entry.RegisterPostEvictionCallback(AfterDeleteFromCache, memoryCache);
                return DateTime.Now;
            });
            if (memoryCache.TryGetValue("keyDelete", out string text))
            {
                return View("Index", dates.TimeOfDay.ToString() + " " + text);
            }
            return View("Index", dates.TimeOfDay.ToString());
        }

        private void AfterDeleteFromCache(object key, object value, EvictionReason reason, object state)
        {
            ((IMemoryCache)state).Set("keyDelete", "удалил минимум раз", new MemoryCacheEntryOptions { Size = 1 });
        }

        public IActionResult TestSizeLimitMemoryCache([FromServices] MyCache1011 memoryCache)
        {

            DateTime dates = memoryCache.MemoryCache.GetOrCreate<DateTime>("key", entry =>
            {
                entry.SetSize(1);
                entry.SetSlidingExpiration(TimeSpan.FromSeconds(10));
                entry.SetAbsoluteExpiration(TimeSpan.FromSeconds(15));
                entry.SetPriority(CacheItemPriority.Normal);
                entry.RegisterPostEvictionCallback(AfterDeleteFromCache, memoryCache);
                return DateTime.Now;
            });
            if (memoryCache.MemoryCache.TryGetValue("keyDelete", out string text))
            {
                return View("Index", dates.TimeOfDay.ToString() + " " + text);
            }
            return View("Index", dates.TimeOfDay.ToString());
        }

        public IActionResult TestWithCtsMemoryCache([FromServices] MyCache1011 memoryCaches, bool val)
        {
            if (val == true)
            {
                var token = new CancellationTokenSource(10000);
                var options = new MemoryCacheEntryOptions().AddExpirationToken(new CancellationChangeToken(token.Token));
                //var options = new MemoryCacheEntryOptions().AddExpirationToken(new CancellationChangeToken(memoryCaches.token.Token));
                options.Size = 1;

                memoryCaches.MemoryCache.Set("key007", DateTime.Now.TimeOfDay.ToString(), options);

         

                return View("Index", "add data");
            }
            var result = memoryCaches.MemoryCache.Get("key007")?.ToString();
            return View("Index", result??"токен отработал, кеш очищен(либо и не был заполнен по этому ключу)");
        }

        public IActionResult CancelToken([FromServices] MyCache1011 memoryCaches)
        {
            memoryCaches.token.Cancel();
            return Ok("токен отменен");
        }
    }
}
