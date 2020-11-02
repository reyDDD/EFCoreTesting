using EFCoreTesting.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            MyTempAttr = val + " " + new Random().Next(1, 111111);
            logger.LogInformation("iz meda danniye po cechu: " + Cache.Count.ToString());

            return View("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    logger.LogInformation("do udaleniya: " + Cache.Count.ToString());
        //    Cache.Compact(0.99); //удаляет указанный процент содержимого кеша
        //    logger.LogInformation("posle udaleniya " + Cache.Count.ToString());
        //    base.Dispose(disposing);
        //}


        //не нашел способа указать Size, который из настроек кеша является обязательным, поэтому для тестировать токена отмены использовал другой кеш
        public IActionResult TestCanceletionToken([FromServices] IMemoryCache cache)
        {
            var token = new CancellationTokenSource(3); //в данном случае не посмотрю факт удаления, если только не установлю задержку

            cache.Set("key1", "znach1", new CancellationChangeToken(token.Token));
            cache.Set("key2", "znach2", new CancellationChangeToken(token.Token));
            logger.LogWarning("before cancel. key1= " + cache.Get("key1"));
            //token.Cancel(); //токен вызывает удаление записи из кеша
            Thread.Sleep(4000); //тест для проверки, что запись в кеше была удалена
            logger.LogWarning("after cancel. key1= " + cache.Get("key1"));
            return View(nameof(Index));
        }



        public IActionResult TestDependantEntry() //Тестирование зависимого доступа
        {
            var token = new CancellationTokenSource(3);
            //другой способ создания записи в кеше
            using (var entry = Cache.CreateEntry("key3"))
            {
                entry.Size = 1;
                entry.Value = "znach3";
                entry.AddExpirationToken(new CancellationChangeToken(token.Token));
            }
            Cache.Set("key4", "znach4", new MemoryCacheEntryOptions() { Size = 1 });

            //если удалить основную запись, связанная никуда не исчезает
            //Cache.Remove("key3");
            //logger.LogWarning("after Remove key3: key4 = " + Cache.Get("key4") + " and key3 = " + Cache.Get("key3"));

            //если удалить зависимую запись, главная никуда не исчезает
            //Cache.Remove("key4");
            //logger.LogWarning("after Remove key4: key4 = " + Cache.Get("key4") + " and key3 = " + Cache.Get("key3"));

            return View(nameof(Index));
        }

        public IActionResult TestDeleteFromCasheFieldWithToken() //Тестирование ситуации, когда удаляется из кеша запись, содержащая токен отмены
        {
            var token = new CancellationTokenSource();
            //другой способ создания записи в кеше
            using (var entry = Cache.CreateEntry("key5"))
            {
                entry.Size = 1;
                entry.Value = token;
            }
            //ниже настраиваю токен изменений на содержимое токена, который содержится в другой записи из кеша
            //ниже пример также показывает, как задать и токен отмены, и установить значение Size
            var opt = new MemoryCacheEntryOptions() { Size = 1 };
            opt.AddExpirationToken(new CancellationChangeToken(Cache.Get<CancellationTokenSource>("key5").Token));
            Cache.Set("key6", "znach6", opt);

            //удаляю из кеша запись с токеном отмены
            Cache.Remove("key5");
            logger.LogWarning("after Remove key5. key6= " + Cache.Get("key6")); //шеста запись остается в кеше!!
            return View(nameof(Index));
        }

    }
}
