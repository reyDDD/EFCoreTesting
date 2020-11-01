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
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(40))
                    ;

                cache.Set("myFirst", $"замостил {DateTime.Now.TimeOfDay}", cacheoption);
            }

            return View("Index", vozvrat);
        }
    }
}
